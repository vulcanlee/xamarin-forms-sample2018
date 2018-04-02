using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Unity.Attributes;

namespace XFPropInject.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private readonly INavigationService _navigationService;
        public string ConstructorInjection { get; set; }
        public string PropertyInjection { get; set; }
        IServiceA _ServiceA;
        public string MethodInjection { get; set; }
        [Dependency]
        public IServiceB _ServiceB { get; set; }
        [Dependency]
        public IPageDialogService _dialogService { get; set; }
        IServiceB _ServiceMethodB;
        public MainPageViewModel(INavigationService navigationService, IServiceA serviceA)
        {
            _navigationService = navigationService;
            _ServiceA = serviceA;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            ConstructorInjection = $"建構式注入 {_ServiceA.MethodA1()} Hash:{_ServiceA.GetHashCode()}";
            PropertyInjection = $"屬性注入 {_ServiceB.MethodB1()} Hash:{_ServiceB.GetHashCode()}";
            MethodInjection = $"方法注入 {_ServiceMethodB.MethodB1()} Hash:{_ServiceMethodB.GetHashCode()}";
            //await _dialogService.DisplayAlertAsync("通知", "完成相依性注入練習", "打完收工");
        }
        public void OnNavigatedTo(NavigationParameters parameters)
        {

        }

        [InjectionMethod]
        public void Initialize(IServiceB serviceMethodB)
        {
            _ServiceMethodB = serviceMethodB;
        }

    }
}
