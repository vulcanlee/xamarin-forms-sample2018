using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace XFCarousel.Models
{
    public class MyItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public string Name { get; set; }
        public Color Background { get; set; }
        public string ImageUrl { get; set; }
    }
}
