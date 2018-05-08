using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace XFUID.ViewModels
{
    public class CrossDeviceInfoVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string AppId { get; set; }
        public string Id { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public string DeviceName { get; set; }
        public string Version { get; set; }
        public string VersionNumber { get; set; }
        public string AppVersion { get; set; }
        public string Platform { get; set; }
        public string Idiom { get; set; }
        public string IsDevice { get; set; }
    }
}
