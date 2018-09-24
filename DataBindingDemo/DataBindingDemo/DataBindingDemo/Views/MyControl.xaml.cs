using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DataBindingDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyControl : ContentView
    {
        public MyControl()
        {
            InitializeComponent();
        }
        public string MyName
        {
            get { return (string)GetValue(MyNameProperty); }
            set { SetValue(MyNameProperty, value); }
        }

        public static readonly BindableProperty MyNameProperty =
            BindableProperty.Create(nameof(MyName),
                typeof(string),
                typeof(MyControl),
                null, BindingMode.TwoWay);

    }
}