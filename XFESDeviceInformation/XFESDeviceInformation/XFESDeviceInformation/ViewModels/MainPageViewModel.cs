using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XFESDeviceInformation.ViewModels
{
    using System.ComponentModel;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    using Xamarin.Essentials;

    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public string Name { get; set; }
        public string VersionString { get; set; }
        public string Platform { get; set; }
        public string Idiom { get; set; }
        public string DeviceType { get; set; }
        private readonly INavigationService _navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            Model = DeviceInfo.Model;
            Manufacturer = DeviceInfo.Manufacturer;
            Name = DeviceInfo.Name;
            VersionString = DeviceInfo.VersionString;
            Platform = DeviceInfo.Platform;
            Idiom = DeviceInfo.Idiom;
            DeviceType = DeviceInfo.DeviceType.ToString();
        }

    }
}
