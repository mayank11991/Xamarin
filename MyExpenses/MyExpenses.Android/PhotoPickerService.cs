using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MyExpenses.Droid;
using MyExpenses.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(PhotoPickerService))]
namespace MyExpenses.Droid
{
    public class PhotoPickerService : IPhotoPickerService
    {
        public Task<Dictionary<string, Stream>> GetImageStreamAsync()
        {
            try
            {
                Intent intent = new Intent();
                intent.SetType("image/*");
                intent.SetAction(Intent.ActionGetContent);

                MainActivity.Instance.StartActivityForResult(
                    Intent.CreateChooser(intent, "Select Picture"),
                    MainActivity.PickImageId);

                MainActivity.Instance.PickImageTaskCompletionSource = new TaskCompletionSource<Dictionary<string, Stream>>();

                return MainActivity.Instance.PickImageTaskCompletionSource.Task;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}