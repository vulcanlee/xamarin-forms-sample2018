using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using PCLStorage;
using XFFileProvider.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(XFFileProvider.Droid.Services.PublicFileSystem))]
namespace XFFileProvider.Droid.Services
{
    class PublicFileSystem : IPublicFileSystem
    {
        public IFolder PublicDownloadFolder
        {
            get
            {
                var localAppData = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads).AbsolutePath;
                return new FileSystemFolder(localAppData);
            }
        }
    }
}