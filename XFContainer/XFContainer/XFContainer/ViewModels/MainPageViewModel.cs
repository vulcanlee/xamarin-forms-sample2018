using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace XFContainer.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        //public delegate void InvalidateSurfaceDelegate();
        //public InvalidateSurfaceDelegate InvalidateSurfaceVM;
        public Action InvalidateSurfaceVM;
        public double BoxViewValue { get; set; }
        public double BoxViewContainerHeight { get; set; }
        public DelegateCommand BoxViewValueChangedCommand { get; set; }
        public DelegateCommand<SKPaintSurfaceEventArgs> PaintSurfaceCommand { get; set; }
        private readonly INavigationService _navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            BoxViewValueChangedCommand = new DelegateCommand(() =>
            {
                double containerHeightDP = 294;
                BoxViewContainerHeight = containerHeightDP * (BoxViewValue / 100.0);
                InvalidateSurfaceVM?.Invoke();
            });

            PaintSurfaceCommand = new DelegateCommand<SKPaintSurfaceEventArgs>(args =>
            {
                SKImageInfo info = args.Info;
                SKSurface surface = args.Surface;
                SKCanvas canvas = surface.Canvas;

                canvas.Clear();

                SKPaint fooOutsideBoxPaint = new SKPaint
                {
                    Style = SKPaintStyle.Stroke,
                    Color = SKColors.Black,
                    StrokeWidth = 3,
                };
                SKPaint fooInsideBoxPaint = new SKPaint
                {
                    Style = SKPaintStyle.Fill,
                    Color = SKColors.White,
                    IsStroke = false,
                };
                SKPaint fooBoxValuePaint = new SKPaint
                {
                    Style = SKPaintStyle.Fill,
                    Color = SKColors.LightPink,
                    IsStroke = false,
                };

                float fooScale = info.Width / 100.0f;
                canvas.Scale(fooScale);

                canvas.DrawRect(0, 0, 100, 300, fooInsideBoxPaint);
                canvas.DrawRect(3, 3, 94, 294, fooOutsideBoxPaint);

                float containerHeightDP = 294f;
                float SkiBoxContainerHeight = containerHeightDP * ((float)BoxViewValue / 100.0f);
                var fooX = 4.0f;
                var fooY = containerHeightDP - SkiBoxContainerHeight+3;
                var fooW = 92f;
                var fooH = SkiBoxContainerHeight;
                Debug.WriteLine($"X:{fooX} Y:{fooY} W:{fooW} H:{fooH}");

                canvas.DrawRect(fooX, fooY, fooW, fooH, fooBoxValuePaint);
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

        }

    }
}
