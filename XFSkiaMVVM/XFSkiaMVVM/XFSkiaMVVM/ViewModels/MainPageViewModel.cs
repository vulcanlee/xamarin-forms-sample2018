using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace XFSkiaMVVM.ViewModels
{
    
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public DelegateCommand<SKPaintSurfaceEventArgs> PaintSurfaceCommand { get; set; }
        public DelegateCommand<SKPaintSurfaceEventArgs> PaintSurfaceSelfScaleCommand { get; set; }
        private readonly INavigationService _navigationService;

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            PaintSurfaceCommand = new DelegateCommand<SKPaintSurfaceEventArgs>(args =>
           {
               SKImageInfo info = args.Info;
               SKSurface surface = args.Surface;
               SKCanvas canvas = surface.Canvas;

               canvas.Clear();

               SKPaint fooCirclePaint = new SKPaint
               {
                   Style = SKPaintStyle.Fill,
                   Color = SKColors.DeepSkyBlue,
                   StrokeWidth=1,
               };

               SKPaint fooLinePaint = new SKPaint
               {
                   Style = SKPaintStyle.Stroke,
                   Color = SKColors.White,
                   StrokeWidth = 1,
               };

               canvas.DrawCircle(100, 100, 100, fooCirclePaint);
               canvas.DrawLine(0, 0, 200, 140, fooLinePaint);
           });

            PaintSurfaceSelfScaleCommand = new DelegateCommand<SKPaintSurfaceEventArgs>(args =>
           {
               SKImageInfo info = args.Info;
               SKSurface surface = args.Surface;
               SKCanvas canvas = surface.Canvas;

               canvas.Clear();

               float fooScale = info.Width / 200.0f;

               SKPaint fooCirclePaint = new SKPaint
               {
                   Style = SKPaintStyle.Fill,
                   Color = SKColors.DeepSkyBlue,
                   StrokeWidth = 1,
               };

               SKPaint fooLinePaint = new SKPaint
               {
                   Style = SKPaintStyle.Stroke,
                   Color = SKColors.White,
                   StrokeWidth = 1,
               };

               canvas.Scale(fooScale);
               canvas.DrawCircle(100, 100, 100, fooCirclePaint);
               canvas.DrawLine(0, 0, 200, 140, fooLinePaint);
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
