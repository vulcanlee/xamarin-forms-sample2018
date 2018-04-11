using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using XFCarousel.Models;

namespace XFCarousel.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<MyItem> MyItemsSource { get; set; } = new ObservableCollection<MyItem>();
        public int MyPosition { get; set; }
        public string Hint { get; set; }
        private readonly INavigationService _navigationService;
        public DelegateCommand MyPositionSelectedCommand { get; set; }

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            MyPositionSelectedCommand = new DelegateCommand(() =>
            {
                Hint = $"您點選了 {MyItemsSource[MyPosition].Name}";
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
            MyItemsSource.Clear();

            MyItemsSource.Add(new MyItem()
            {
                Name = "LightBlue",
                Background = Color.LightBlue,
                ImageUrl = "https://avatars2.githubusercontent.com/u/790012?s=200&v=4",
            });
            MyItemsSource.Add(new MyItem()
            {
                Name = "LightCoral",
                Background = Color.LightCoral,
                ImageUrl = "http://icons.iconarchive.com/icons/graphicloads/100-flat/256/home-icon.png",
            });
            MyItemsSource.Add(new MyItem()
            {
                Name = "LightCyan",
                Background = Color.LightCyan,
                ImageUrl = "http://icons.iconarchive.com/icons/graphicloads/100-flat-2/256/mobile-2-icon.png",
            });
            MyItemsSource.Add(new MyItem()
            {
                Name = "LightGoldenrodYellow",
                Background = Color.LightGoldenrodYellow,
                ImageUrl = "http://files.softicons.com/download/game-icons/super-mario-icons-by-sandro-pereira/png/256/Mushroom%20-%20Super.png",
            });
            MyItemsSource.Add(new MyItem()
            {
                Name = "LightGreen",
                Background = Color.LightGreen,
                ImageUrl = "http://images.all-free-download.com/images/graphiclarge/harry_potter_icon_6825007.jpg",
            });
            MyItemsSource.Add(new MyItem()
            {
                Name = "LightSlateGray",
                Background = Color.LightSlateGray,
                ImageUrl = "http://www.icosky.com/icon/png/Movie%20%26%20TV/Doraemon/smile.png",
            });
            MyItemsSource.Add(new MyItem()
            {
                Name = "LimeGreen",
                Background = Color.LimeGreen,
                ImageUrl = "http://images.pocketgamer.co.uk/artwork/imgthumbs/na-owuz/10_mario_facts11.jpg",
            });
            MyItemsSource.Add(new MyItem()
            {
                Name = "LightSalmon",
                Background = Color.LightSalmon,
                ImageUrl = "https://rocketdock.com/images/screenshots/thumbnails/Awesome_small.png",
            });
            MyItemsSource.Add(new MyItem()
            {
                Name = "LightGray",
                Background = Color.LightGray,
                ImageUrl = "http://wikiclipart.com/wp-content/uploads/2018/01/Pig-face-cute-face-finance-happy-hog-pig-piggy-icon-icon-search-engine-clip-art.png",
            });
        }

    }
}
