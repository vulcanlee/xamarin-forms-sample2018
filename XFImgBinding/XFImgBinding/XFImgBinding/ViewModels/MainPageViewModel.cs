using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XFImgBinding.ViewModels
{
    using System.ComponentModel;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public int ImageStatus { get; set; }
        public string ShowImage { get; set; }
        public DelegateCommand CallWebCommand { get; set; }
        private readonly INavigationService _navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            CallWebCommand = new DelegateCommand(async () =>
            {
                await GetWebAndShowImageAsync();
            });

            GetWebAndShowImage();
        }

        public async void GetWebAndShowImage()
        {
            var client = new HttpClient();
            var fooTmp = await client.GetStringAsync("https://www.google.com");
            ShowImage = $"facebook{(ImageStatus++ % 2) + 1}.png";
        }
        public async Task GetWebAndShowImageAsync()
        {
            var client = new HttpClient();
            var fooTmp = await client.GetStringAsync("https://www.google.com");
            ShowImage = $"facebook{(ImageStatus++ % 2) + 1}.png";
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
}
