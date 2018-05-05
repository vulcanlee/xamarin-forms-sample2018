using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFContainer.ViewModels;

namespace XFContainer.Views
{
	public partial class MainPage : ContentPage
	{
        public MainPage ()
		{
			InitializeComponent ();
            this.BindingContextChanged += (s, e) =>
            {
                var foo = s as MainPage;
                if(foo != null)
                {
                    if(foo.BindingContext != null)
                    {
                        var VM = this.BindingContext as MainPageViewModel;
                        VM.InvalidateSurfaceVM = this.skCanvasView.InvalidateSurface;
                    }
                }
            };
		}
    }
}