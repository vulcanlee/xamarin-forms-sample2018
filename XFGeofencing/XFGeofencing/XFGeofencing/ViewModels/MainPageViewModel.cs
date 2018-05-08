using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace XFGeofencing.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string GPSLocation { get; set; }
        public DelegateCommand GetGPSCommand { get; set; }
        private readonly INavigationService _navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            GetGPSCommand = new DelegateCommand(async () =>
            {
                if (!Plugin.Geolocator.CrossGeolocator.IsSupported)
                    return ;
                try
                {
                    var fooLocation = await Plugin.Geolocator.CrossGeolocator.Current.GetPositionAsync();
                    GPSLocation = $"Latitude : {fooLocation.Latitude} Longitude : {fooLocation.Longitude}";
                }
                catch { }
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
