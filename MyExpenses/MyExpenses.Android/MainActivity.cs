using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;
using Android.Content;
using Xamarin.Forms.Platform.Android;

namespace MyExpenses.Droid
{
    [Activity(Label = "MyExpenses", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : FormsAppCompatActivity
    {
        public static readonly int PickImageId = 1000;
        public TaskCompletionSource<Dictionary<string, Stream>> PickImageTaskCompletionSource { set; get; }
        internal static MainActivity Instance { get; set; }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Instance = this;
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent intent)
        {
            base.OnActivityResult(requestCode, resultCode, intent);

            if (requestCode == PickImageId)
            {
                if ((resultCode == Result.Ok) && (intent != null))
                {
                    Android.Net.Uri uri = intent.Data;
                    Stream stream = ContentResolver.OpenInputStream(uri);

                    Dictionary<string, Stream> dic = new Dictionary<string, Stream>();
                    dic.Add(uri.ToString(), stream);
                    PickImageTaskCompletionSource.SetResult(dic);
                }
                else
                {
                    PickImageTaskCompletionSource.SetResult(null);
                }
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}