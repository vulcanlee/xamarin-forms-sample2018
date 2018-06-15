using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XFESFileSystem.ViewModels
{
    using System.ComponentModel;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Account { get; set; }
        public string Password { get; set; }
        public DelegateCommand CleanCommand { get; set; }
        public DelegateCommand SaveCommand { get; set; }
        public DelegateCommand ReadCommand { get; set; }
        private readonly INavigationService _navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            CleanCommand = new DelegateCommand(() =>
            {
                Account = "";
                Password = "";
            });
            SaveCommand = new DelegateCommand(() =>
            {
                var foo = new MyUser()
                {
                    Account = Account,
                    Password = Password,
                };
                var fooSerial = Newtonsoft.Json.JsonConvert.SerializeObject(foo);
                var mainDir = Xamarin.Essentials.FileSystem.AppDataDirectory;
                var fileName = System.IO.Path.Combine(mainDir, "MyData.txt");
                System.IO.File.WriteAllText(fileName, fooSerial);
            });
            ReadCommand = new DelegateCommand(() =>
            {
                var mainDir = Xamarin.Essentials.FileSystem.AppDataDirectory;
                var fileName = System.IO.Path.Combine(mainDir, "MyData.txt");
                var fooSerial= System.IO.File.ReadAllText(fileName);
                var foo = Newtonsoft.Json.JsonConvert.DeserializeObject<MyUser>(fooSerial);
                if(foo!=null)
                {
                    Account = foo.Account;
                    Password = foo.Password;
                }
            });
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {

        }

    }

    public class MyUser
    {
        public string Account { get; set; }
        public string Password { get; set; }
    }
}
