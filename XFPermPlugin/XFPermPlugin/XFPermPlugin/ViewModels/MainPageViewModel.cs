using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XFPermPlugin.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public DelegateCommand CheckPermissionCommand { get; set; }
        public readonly IPageDialogService _dialogService;
        public MainPageViewModel(INavigationService navigationService,
            IPageDialogService dialogService) 
            : base (navigationService)
        {
            _dialogService = dialogService;
            Title = "Main Page";
            CheckPermissionCommand = new DelegateCommand(async () =>
            {
                var fooStatus = await Plugin.Permissions.CrossPermissions
                .Current.CheckPermissionStatusAsync(Plugin.Permissions.Abstractions.Permission.Storage);
                if (fooStatus != Plugin.Permissions.Abstractions.PermissionStatus.Granted)
                {
                    if (await Plugin.Permissions.CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync
                    (Plugin.Permissions.Abstractions.Permission.Storage))
                    {
                        await _dialogService.DisplayAlertAsync("Need Storage", "Gunna need that Storage", "OK");
                    }

                    var results = await Plugin.Permissions.CrossPermissions.Current.RequestPermissionsAsync
                    (Plugin.Permissions.Abstractions.Permission.Storage);
                    //Best practice to always check that the key exists
                    if (results.ContainsKey(Plugin.Permissions.Abstractions.Permission.Storage))
                        fooStatus = results[Plugin.Permissions.Abstractions.Permission.Storage];
                }

                if (fooStatus == Plugin.Permissions.Abstractions.PermissionStatus.Granted)
                {
                    await _dialogService.DisplayAlertAsync("Storage Allow", "You can continue to call any storage API.", "OK");
                }
                else if (fooStatus != Plugin.Permissions.Abstractions.PermissionStatus.Unknown)
                {
                    await _dialogService.DisplayAlertAsync("Storage Denied", "Can not continue, try again.", "OK");
                }
            });
        }
    }
}
