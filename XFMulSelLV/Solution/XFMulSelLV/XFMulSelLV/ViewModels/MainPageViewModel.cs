using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace XFMulSelLV.ViewModels
{
    public class Person : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Name { get; set; }
        public int Age { get; set; }
        public bool IsSelected { get; set; }

    }

    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Person> PeopleCollection { get; set; } = new ObservableCollection<Person>();
        public Person PersonSelected { get; set; }
        public string Title { get; set; } 
        public DelegateCommand PersonTappedCommand { get; set; }
        public DelegateCommand ShowResultCommand { get; set; }
        private readonly INavigationService _navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            PersonTappedCommand = new DelegateCommand(() =>
            {
                PersonSelected.IsSelected = !PersonSelected.IsSelected;
            });
            ShowResultCommand = new DelegateCommand(() =>
            {
                var fooCount = 0;
                foreach (var item in PeopleCollection)
                {
                    if(item.IsSelected == true)
                    {
                        fooCount++;
                    }
                }
                Title = $"共選擇 {fooCount} 筆紀錄";
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
            PeopleCollection.Clear();
            for (int i = 0; i < 100; i++)
            {
                PeopleCollection.Add(new Person
                {
                    Name = $"Name{i}",
                    Age = i,
                    IsSelected = false
                });
            }
        }

    }
}
