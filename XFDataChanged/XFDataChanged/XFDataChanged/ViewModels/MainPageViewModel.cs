using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XFDataChanged.ViewModels
{
    using System.ComponentModel;
    using Prism.Events;
    using Prism.Navigation;
    using Prism.Services;
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public bool Option1 { get; set; }
        public bool Option2 { get; set; }
        public bool Option3 { get; set; }
        public string YourChoice { get; set; }
        private readonly INavigationService _navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }
        public void OnOption1Changed()
        {
            SetOption(nameof(Option1));
        }
        public void OnOption2Changed()
        {
            SetOption(nameof(Option2));
        }
        public void OnOption3Changed()
        {
            SetOption(nameof(Option3));
        }
        public void OnNavigatedTo(NavigationParameters parameters)
        {
            ResetOptions();
        }

        public void ResetOptions()
        {
            SetOption(nameof(Option1));
        }
        public bool CorrelationAction { get; set; }
        public void SetOption(string choiceOption)
        {
            if (CorrelationAction == true) return;
            CorrelationAction = true;
            switch (choiceOption)
            {
                case nameof(Option1):
                    Option1 = true;
                    Option2 = false;
                    Option3 = false;
                    break;
                case nameof(Option2):
                    Option1 = false;
                    Option2 = true;
                    Option3 = false;
                    break;
                case nameof(Option3):
                    Option1 = false;
                    Option2 = false;
                    Option3 = true;
                    break;
                default:
                    break;
            }
            YourChoice = choiceOption;
            CorrelationAction = false;
        }
    }
}
