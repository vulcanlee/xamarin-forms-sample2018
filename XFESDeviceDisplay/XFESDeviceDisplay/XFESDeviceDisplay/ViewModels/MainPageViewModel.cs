using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XFESDeviceDisplay.ViewModels
{
    using System.ComponentModel;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    using Xamarin.Essentials;

    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Orientation { get; set; }
        public string Rotation { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Density { get; set; }
        public DelegateCommand RefreshCommand { get; set; }
        private readonly INavigationService _navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            RefreshCommand = new DelegateCommand(() =>
            {
                Refresh(DeviceDisplay.ScreenMetrics);
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
            Refresh(DeviceDisplay.ScreenMetrics);

            DeviceDisplay.ScreenMetricsChanaged += (x) =>
            {
                Refresh(x.Metrics);
            };
        }

        public void Refresh(ScreenMetrics screenMetrics)
        {
            Orientation = screenMetrics.Orientation.ToString();
            Rotation = screenMetrics.Rotation.ToString();
            Width = screenMetrics.Width;
            Height = screenMetrics.Height;
            Density = screenMetrics.Density;
        }
    }
}
