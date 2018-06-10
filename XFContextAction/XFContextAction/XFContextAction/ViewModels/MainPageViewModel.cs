using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XFContextAction.ViewModels
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<MyDataItem> MyDatasSource { get; set; } = new ObservableCollection<MyDataItem>();
        public MyDataItem MyDataSelected { get; set; }
        private readonly INavigationService _navigationService;
        public DelegateCommand<MyDataItem> Option1Command { get; set; }
        public DelegateCommand<MyDataItem> Option2Command { get; set; }
        public readonly IPageDialogService _dialogService;
        public MainPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;

            Option1Command = new DelegateCommand<MyDataItem>(async (x) =>
            {
                await _dialogService.DisplayAlertAsync("你按下了", $"{x.Title} 的第1個 ActionMenu", "OK");
            });

            Option2Command = new DelegateCommand<MyDataItem>(async (x) =>
            {
                await _dialogService.DisplayAlertAsync("你按下了", $"{x.Title} 的第2個 ActionMenu", "OK");
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
            for (int i = 0; i < 20; i++)
            {
                MyDatasSource.Add(new MyDataItem()
                {
                    Title = $"主題 ~~{i}~~"
                });
            }
        }

    }

    public class MyDataItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Title { get; set; }

    }
}
