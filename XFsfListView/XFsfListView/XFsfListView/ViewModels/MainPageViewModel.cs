using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XFsfListView.Models;
using XFsfListView.Services;

namespace XFsfListView.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        int cycle = 0;
        #region Items Property
        private ObservableCollection<PizzaItem> _Items = new ObservableCollection<PizzaItem>();
        public ObservableCollection<PizzaItem> Items
        {
            get { return _Items; }
            set { SetProperty(ref _Items, value); }
        }
        #endregion

        #region IsRefreshing Property
        private bool _IsRefreshing;
        public bool IsRefreshing
        {
            get { return _IsRefreshing; }
            set { SetProperty(ref _IsRefreshing, value); }
        }
        #endregion

        #region IsBusy  Property
        private bool _IsBusy;
        public bool IsBusy
        {
            get { return _IsBusy; }
            set { SetProperty(ref _IsBusy, value); }
        }
        #endregion

        #region IsReorder Property
        private bool _IsReorder;
        public bool IsReorder
        {
            get { return _IsReorder; }
            set { SetProperty(ref _IsReorder, value); }
        }
        #endregion

        public DelegateCommand RefreshingCommand { get; set; }
        public DelegateCommand LoadMoreItemsCommand { get; set; }
        public MainPageViewModel(INavigationService navigationService)
             : base(navigationService)
        {
            Title = "sfListView 功能練習";

            IsReorder = true;

            RefreshingCommand = new DelegateCommand(async () =>
            {
                IsRefreshing = true;
                Items.Clear();
                await Task.Delay(2000);

                PizzaRepository pr = new PizzaRepository();

                var fooItems = pr.Get(cycle++);
                foreach (var item in fooItems)
                {
                    Items.Add(item);
                }

                IsRefreshing = false;
            });

            LoadMoreItemsCommand = new DelegateCommand(async() =>
            {
                if (IsRefreshing == true)
                    return;
                PizzaRepository pr = new PizzaRepository();
                IsBusy = true;

                await Task.Delay(1500);
                var fooItems = pr.Get(cycle++);
                foreach (var item in fooItems)
                {
                    Items.Add(item);
                }

                IsBusy = false;
            });
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            PizzaRepository pr = new PizzaRepository();

            var fooItems = pr.Get(cycle++);
            foreach (var item in fooItems)
            {
                Items.Add(item);
            }
        }
    }
}
