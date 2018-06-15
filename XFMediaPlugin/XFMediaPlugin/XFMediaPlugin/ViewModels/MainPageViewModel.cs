using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XFMediaPlugin.ViewModels
{
    using System.ComponentModel;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    using Xamarin.Forms;

    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ImageSource MyImageSource { get; set; } = ImageSource.FromFile("DefaultImage.jpg");
        public DelegateCommand TapCommand { get; set; }
        private readonly INavigationService _navigationService;
        public readonly IPageDialogService _dialogService;
        public MainPageViewModel(INavigationService navigationService,
            IPageDialogService dialogService)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;

            TapCommand = new DelegateCommand(async () =>
            {
                // 進行 Plugin.Media 套件的初始化動作
                await Plugin.Media.CrossMedia.Current.Initialize();

                // 確認這個裝置是否具有拍照的功能
                if (!Plugin.Media.CrossMedia.Current.IsCameraAvailable || !Plugin.Media.CrossMedia.Current.IsTakePhotoSupported)
                {
                    await _dialogService.DisplayAlertAsync("No Camera", ":( No camera available.", "OK");
                    return;
                }

                // 啟動拍照功能，並且儲存到指定的路徑與檔案中
                var file = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    Directory = "Sample",
                    Name = "Sample.jpg"
                });

                if (file == null)
                    return;

                // 讀取剛剛拍照的檔案內容，轉換成為 ImageSource，如此，就可以顯示到螢幕上了

                MyImageSource = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();
                    return stream;
                });
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
