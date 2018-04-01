using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace XFModalNavi.ViewModels
{
    public class HomePageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly INavigationService _navigationService;

        public DelegateCommand GoPage1Command { get; set; }
        public DelegateCommand GoPage2Command { get; set; }
        public DelegateCommand GoPage1ModalCommand { get; set; }
        public DelegateCommand GoPage2ModalCommand { get; set; }
        public DelegateCommand GoPage1NaviCommand { get; set; }
        public DelegateCommand GoPage2NaviCommand { get; set; }
        public DelegateCommand GoPage3NaviCommand { get; set; }
        public DelegateCommand GoPage4NaviCommand { get; set; }
        public HomePageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            GoPage1Command = new DelegateCommand(async () =>
            {
                await _navigationService.NavigateAsync("Page1Page");
            });
            GoPage2Command = new DelegateCommand(async () =>
            {
                await _navigationService.NavigateAsync("Page1Page/Page2Page");
            });

            GoPage1ModalCommand = new DelegateCommand(async () =>
            {
                await _navigationService.NavigateAsync("Page1Page", null, true);
            });
            GoPage2ModalCommand = new DelegateCommand(async () =>
            {
                await _navigationService.NavigateAsync("Page1Page/Page2Page", null, true);
            });

            GoPage1NaviCommand = new DelegateCommand(async () =>
            {
                await _navigationService.NavigateAsync("NavigationPage/Page1Page", null, true);
            });
            GoPage2NaviCommand = new DelegateCommand(async () =>
            {
                await _navigationService.NavigateAsync("NavigationPage/Page3Page", null, true);
            });
            GoPage3NaviCommand = new DelegateCommand(async () =>
            {
                await _navigationService.NavigateAsync("NavigationPage/Page3Page/Page2Page", null, true);
            });
            GoPage4NaviCommand = new DelegateCommand(async () =>
            {
                await _navigationService.NavigateAsync("NavigationPage/Page3Page/Page4Page", null, true);
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
