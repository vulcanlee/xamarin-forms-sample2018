using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XFESGeolocation.ViewModels
{
    using System.ComponentModel;
    using System.Threading;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    using Xamarin.Essentials;

    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string YourLocation { get; set; }
        public bool GetLocation { get; set; }
        public DelegateCommand GetLocationCommand { get; set; }
        public DelegateCommand CancelLocationCommand { get; set; }
        private readonly INavigationService _navigationService;
        public CancellationTokenSource CTS { get; set; }
        public CancellationToken Token { get; set; }

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            GetLocationCommand = new DelegateCommand(async () =>
            {
                CTS = new CancellationTokenSource();
                Token = CTS.Token;
                GetLocation = true;

                try
                {
                    var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                    var location = await Geolocation.GetLocationAsync(request, Token);

                    if (location != null)
                    {
                        YourLocation = $"Latitude 緯度 : {location.Latitude}, Longitude 經度 : {location.Longitude}";
                    }
                }
                catch (FeatureNotSupportedException fnsEx)
                {
                    // 處理裝置不支援這項功能的例外異常
                }
                catch (PermissionException pEx)
                {
                    // 處理關於權限上的例外異常
                }
                catch (AggregateException ae)
                {
                    // 處理取消的例外異常
                }
                catch (Exception ex)
                {
                    // 無法取得該GPS位置之例外異常
                }

                GetLocation = false;
            });
            CancelLocationCommand = new DelegateCommand(() =>
            {
                GetLocation = false;
                CTS.Cancel();
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
