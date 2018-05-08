using Plugin.DeviceInfo;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace XFUID.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public CrossDeviceInfoVM DeviceInfo { get; set; }
        private readonly INavigationService _navigationService;
        public DelegateCommand GetDeviceInfoCommand { get; set; }
        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            GetDeviceInfoCommand = new DelegateCommand(() =>
            {
                GetDeviceInfo();
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

        void GetDeviceInfo()
        {
            DeviceInfo = new CrossDeviceInfoVM();
            DeviceInfo.AppId = CrossDeviceInfo.Current.GenerateAppId(true, "Vulcan", "Lee");
            DeviceInfo.Id = CrossDeviceInfo.Current.Id;
            DeviceInfo.Model = CrossDeviceInfo.Current.Model;
            DeviceInfo.Manufacturer = CrossDeviceInfo.Current.Manufacturer;
            DeviceInfo.DeviceName = CrossDeviceInfo.Current.DeviceName;
            DeviceInfo.Version = CrossDeviceInfo.Current.Version;
            DeviceInfo.VersionNumber = CrossDeviceInfo.Current.VersionNumber.ToString();
            DeviceInfo.AppVersion = CrossDeviceInfo.Current.AppVersion;
            DeviceInfo.Platform = CrossDeviceInfo.Current.Platform.ToString();
            DeviceInfo.Idiom = CrossDeviceInfo.Current.Idiom.ToString();
            DeviceInfo.IsDevice = CrossDeviceInfo.Current.IsDevice.ToString();
        }
    }
}
