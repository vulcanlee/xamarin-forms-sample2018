using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XFESClipboard.ViewModels
{
    using System.ComponentModel;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    using Xamarin.Essentials;

    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string MyEntry { get; set; }
        public DelegateCommand<string> LabelTapCommand { get; set; }
        public DelegateCommand RetriveClipboardCommand { get; set; }
        private readonly INavigationService _navigationService;
        public Plugin.Toasts.IToastNotificator _ToastNotificator { get; set; }
        public MainPageViewModel(INavigationService navigationService,
            Plugin.Toasts.IToastNotificator toastNotificator)
        {
            _navigationService = navigationService;
            _ToastNotificator = toastNotificator;

            LabelTapCommand = new DelegateCommand<string>(async (x) =>
            {
                Clipboard.SetText(x);
                await _ToastNotificator.Notify(new Plugin.Toasts.NotificationOptions()
                {
                    Title = $"通知",
                    Description = $"{MyEntry} 已經複製到剪貼簿中"
                });
            });

            RetriveClipboardCommand = new DelegateCommand(async () =>
            {
                if( Clipboard.HasText )
                {
                    MyEntry = $"產生自剪貼簿:{await Clipboard.GetTextAsync()}";
                }
                else
                {
                    await _ToastNotificator.Notify(new Plugin.Toasts.NotificationOptions()
                    {
                        Title = $"警告",
                        Description = $"剪貼簿內沒有任何資料"
                    });
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
}
