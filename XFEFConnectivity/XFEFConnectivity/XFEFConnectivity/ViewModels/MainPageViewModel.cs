using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XFEFConnectivity.ViewModels
{
    using System.ComponentModel;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    using Xamarin.Essentials;

    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string ConnectivityStatus { get; set; }
         public string Profiles { get; set; }
       private readonly INavigationService _navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            Init();
        }

        private void Init()
        {
            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {
                ConnectivityStatus = "網際網路-本機和網際網路存取";
            }
            else if (current == NetworkAccess.ConstrainedInternet)
            {
                ConnectivityStatus = "ConstrainedInternet – 受限的網際網路存取。 指出網頁驗證入口網站的連線能力，其中提供入口網站的本機存取，但存取網際網路需要透過入口網站提供了特定的憑證。";
            }
            else if (current == NetworkAccess.Local)
            {
                ConnectivityStatus = "本機– 本機網路僅限存取。";
            }
            else if (current == NetworkAccess.None)
            {
                ConnectivityStatus = "無– 沒有連線可用。";
            }
            else if (current == NetworkAccess.Unknown)
            {
                ConnectivityStatus = "未知– 無法判定網際網路連線。";
            }

            var profiles = Connectivity.Profiles;
            Profiles = "裝置中正在使用的連線類型 : ";
            if (profiles.Contains(ConnectionProfile.WiFi))
            {
                Profiles += " WiFi ";
            }
            if (profiles.Contains(ConnectionProfile.Bluetooth))
            {
                Profiles += " Bluetooth ";
            }
            if (profiles.Contains(ConnectionProfile.Cellular))
            {
                Profiles += " Cellular ";
            }
            if (profiles.Contains(ConnectionProfile.Ethernet))
            {
                Profiles += " Ethernet ";
            }
            if (profiles.Contains(ConnectionProfile.Other))
            {
                Profiles += " Other ";
            }
            if (profiles.Contains(ConnectionProfile.WiMAX))
            {
                Profiles += " WiMAX ";
            }
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
