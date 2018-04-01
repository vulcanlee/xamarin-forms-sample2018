using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace XFModalNavi.ViewModels
{
    public class Page4PageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly INavigationService _navigationService;
        public DelegateCommand GoBackCommand { get; set; }

        public Page4PageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            GoBackCommand = new DelegateCommand(async () =>
            {
                var fooPage = App.Current.MainPage;
                var fooNavigationStack = fooPage.Navigation.NavigationStack;
                var fooModalStack = fooPage.Navigation.ModalStack;
                await fooPage.Navigation.PopModalAsync();
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
}
