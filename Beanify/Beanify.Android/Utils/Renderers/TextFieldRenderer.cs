using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using Beanify.Droid.Utils.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
[assembly: ExportRenderer(typeof(Entry), typeof(TextFieldRenderer))]
namespace Beanify.Droid.Utils.Renderers
{
    public class TextFieldRenderer : EntryRenderer
    {
        public TextFieldRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
                Control.ImeOptions = (ImeAction)ImeFlags.NoExtractUi;
        }
    }
}