using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using XFFileProvider.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(XFFileProvider.Droid.Services.OpenFileByName))]
namespace XFFileProvider.Droid.Services
{
    class OpenFileByName : IOpenFileByName
    {
        public void MakeDownloadFolder(string fullFileName, string mimeType)
        {
            var filePath = fullFileName;
            var fileName = Path.GetFileName(fullFileName);
            Java.IO.File file = new Java.IO.File(fullFileName);

            var context = Android.App.Application.Context;
            DownloadManager downloadManager = (DownloadManager)context.GetSystemService(Context.DownloadService);
            downloadManager.AddCompletedDownload(fileName, fileName, true, mimeType, fullFileName, file.Length(), true);
        }

        private int ResolvePackageTargetSdkVersion()
        {
            int sdkVersion;
            try
            {
                sdkVersion = (int)Android.App.Application.Context.ApplicationInfo.TargetSdkVersion;
            }
            catch (Exception)
            {
                var appInfo = Android.App.Application.Context.PackageManager.GetApplicationInfo(Android.App.Application.Context.PackageName, 0);
                sdkVersion = (int)appInfo.TargetSdkVersion;
            }

            return sdkVersion;
        }

        public void OpenFile(string fullFileName)
        {
            try
            {
                Java.IO.File file = new Java.IO.File(fullFileName);
                file.SetReadable(true);

                string application = "";

                application = "application/pdf";

                var targetSdk = ResolvePackageTargetSdkVersion();
                if (targetSdk < 24)
                {
                    Android.Net.Uri uri = Android.Net.Uri.FromFile(file);
                    Intent intent = new Intent(Intent.ActionView);
                    intent.SetDataAndType(uri, application);
                    intent.SetFlags(ActivityFlags.ClearWhenTaskReset | ActivityFlags.NewTask);

                    Android.App.Application.Context.StartActivity(intent);
                    try
                    {
                        Android.App.Application.Context.StartActivity(intent);
                    }
                    catch (Exception)
                    {
                        Toast.MakeText(Android.App.Application.Context, "No Application Available to View this file.", ToastLength.Short).Show();
                    }
                }
                else
                {
                    var foo = Android.App.Application.Context.PackageName + ".fileprovider";
                    Android.Net.Uri uri = Android.Support.V4.Content.FileProvider.GetUriForFile(
                        Android.App.Application.Context,
                        foo, file);

                    Intent intent = new Intent(Intent.ActionView);
                    intent.SetDataAndType(uri, application);
                    intent.AddFlags(ActivityFlags.GrantReadUriPermission);
                    intent.AddFlags(ActivityFlags.NoHistory);
                    intent.AddFlags(ActivityFlags.ClearWhenTaskReset | ActivityFlags.NewTask);

                    try
                    {
                        Android.App.Application.Context.StartActivity(intent);
                    }
                    catch (Exception)
                    {
                        Toast.MakeText(Android.App.Application.Context, "No Application Available to View this file.", ToastLength.Short).Show();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}