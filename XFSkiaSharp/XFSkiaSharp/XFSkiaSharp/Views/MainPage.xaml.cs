using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFSkiaSharp.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            SKPaint paint = new SKPaint
            {
                Style = SKPaintStyle.Fill,
                Color = SKColors.LightBlue,
                StrokeWidth = 1,

            };
            canvas.DrawRect(0, 0, 80, 200, paint);

            label1.Text = $"SKCanvasView Independent Pixel= {canvasView.Width} x {canvasView.Height} ";
            label2.Text = $"SKCanvasView Pixel= {canvasView.CanvasSize.Width} x {canvasView.CanvasSize.Height} ";
            label3.Text = $"SKCanvasView Scale = {canvasView.CanvasSize.Width / canvasView.Width} x {canvasView.CanvasSize.Height / canvasView.Height} ";
        }
        void OnCanvasViewPaintSurfaceScale(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            float fooScale = 2.65f;
            SKPaint paint = new SKPaint
            {
                Style = SKPaintStyle.Fill,
                Color = SKColors.LightBlue,
                StrokeWidth = 1,

            };
            canvas.DrawRect(0, 0, 80 * fooScale, 200 * fooScale, paint);
        }
        void OnCanvasViewPaintSurfaceScale2(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            SKPaint paint = new SKPaint
            {
                Style = SKPaintStyle.Fill,
                Color = SKColors.LightBlue,
                StrokeWidth = 1,

            };
            canvas.Scale(2.65f);
            canvas.DrawRect(0, 0, 80, 200, paint);
        }
    }
}