using Prism;
using Prism.Ioc;
using XFPropInject.ViewModels;
using XFPropInject.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.Unity;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XFPropInject
{
    public partial class App : PrismApplication
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage>();

            containerRegistry.Register<IServiceA, ServiceA>();
            containerRegistry.Register<IServiceB, ServiceB>();
        }
    }
    public interface IServiceA
    {
        string MethodA1();
    }

    public interface IServiceB
    {
        string MethodB1();
    }

    public class ServiceA : IServiceA
    {
        public string MethodA1()
        {
            return "MethodA1() " ;
        }
    }

    public class ServiceB : IServiceB
    {
        public string MethodB1()
        {
            return "MethodB1() ";
        }
    }
}
