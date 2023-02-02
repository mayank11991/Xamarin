using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MyExpenses.Droid.Renderer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Entry), typeof(NoUnderLineEntryRenderer))]
namespace MyExpenses.Droid.Renderer
{
    public class NoUnderLineEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            this.Control.Background = Forms.Context.GetDrawable(Resource.Drawable.BackgroundEntry);
            Control?.SetPadding(20, 20, 20, 20);
        }
    }
}