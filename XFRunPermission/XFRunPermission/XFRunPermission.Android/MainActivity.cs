using Android.App;
using Android.Content.PM;
using Android.OS;
using Prism;
using Prism.Events;
using Prism.Ioc;
using XFRunPermission.Events;

[assembly: UsesPermission(Name = Android.Manifest.Permission.ReadExternalStorage)]
[assembly: UsesPermission(Name = Android.Manifest.Permission.WriteExternalStorage)]
[assembly: UsesPermission(Name = Android.Manifest.Permission.Camera)]
[assembly: UsesPermission(Name = Android.Manifest.Permission.CallPhone)]
namespace XFRunPermission.Droid
{
    [Activity(Label = "XFRunPermission", Icon = "@mipmap/ic_launcher", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        IEventAggregator fooIEventAggregator;
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App(new AndroidInitializer()));

            var fooContainer = ((App.Current) as Prism.Unity.PrismApplication).Container;
            fooIEventAggregator = fooContainer.Resolve<IEventAggregator>();
            fooIEventAggregator.GetEvent<RuntimePermissionEvent>().Subscribe(x =>
            {
                CheckPermissions();
            });
        }

        void CheckPermissions()
        {
            if ((int)Build.VERSION.SdkInt < 23)
            {
                return;
            }

            var fooRead = CheckSelfPermission(Android.Manifest.Permission.ReadExternalStorage);
            var fooWrite = CheckSelfPermission(Android.Manifest.Permission.WriteExternalStorage);
            if ((fooRead == (int)Permission.Granted) && (fooWrite == (int)Permission.Granted))
            {
                var foo = 0;
            }
            else
            {
                Android.Support.V4.App.ActivityCompat.RequestPermissions(this,
                    new string[] { Android.Manifest.Permission.ReadExternalStorage, Android.Manifest.Permission.WriteExternalStorage,
                    Android.Manifest.Permission.CallPhone, Android.Manifest.Permission.Camera}, 4);
            }
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            var foo = 1;
        }
    }

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry container)
        {
            // Register any platform specific implementations
        }
    }
}

