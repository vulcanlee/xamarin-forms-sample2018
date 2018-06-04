using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XFFileProvider.ViewModels
{
    using System.ComponentModel;
    using PCLStorage;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    using XFFileProvider.Events;
    using XFFileProvider.Interfaces;

    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public DelegateCommand AskPermissionCommand { get; set; }
        public DelegateCommand OpenPDFCommand { get; set; }
        private readonly IPublicFileSystem _publicFileSystem;

        private readonly IOpenFileByName _openFileByName;
        private readonly IEventAggregator _eventAggregator;

        private readonly INavigationService _navigationService;

        public MainPageViewModel(INavigationService navigationService, IPublicFileSystem publicFileSystem,
            IOpenFileByName openFileByName, IEventAggregator eventAggregator)
        {
            _navigationService = navigationService;
            _eventAggregator = eventAggregator;
            _publicFileSystem = publicFileSystem;
            _openFileByName = openFileByName;
            AskPermissionCommand = new DelegateCommand(() =>
            {
                _eventAggregator.GetEvent<RuntimePermissionEvent>().Publish(new RuntimePermissionPayload());
            });
            OpenPDFCommand = new DelegateCommand(async () =>
            {
                string filename = "PDF.pdf";
                IFolder rootFolder = _publicFileSystem.PublicDownloadFolder;
                IFile file = await rootFolder.CreateFileAsync(filename, CreationCollisionOption.OpenIfExists);
                await file.WriteAllTextAsync("123");
                _openFileByName.OpenFile(file.Path);
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
