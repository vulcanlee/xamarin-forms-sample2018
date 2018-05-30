using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XFRunPermission.Events;

namespace XFRunPermission.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly IEventAggregator _eventAggregator;
        public DelegateCommand CheckPermissionCommand { get; set; }
        public MainPageViewModel(INavigationService navigationService,
            IEventAggregator eventAggregator) 
            : base (navigationService)
        {
            _eventAggregator = eventAggregator;
            CheckPermissionCommand = new DelegateCommand(() =>
            {
                _eventAggregator.GetEvent<RuntimePermissionEvent>().Publish(
                    new RuntimePermissionPayload());
            });
            Title = "Main Page";
        }
    }
}
