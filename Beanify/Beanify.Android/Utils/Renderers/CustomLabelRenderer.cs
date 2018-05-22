using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using Beanify.Droid.Utils.Renderers;
using Xamarin.Forms;
using Beanify.Utils.Controls;

[assembly: ExportRenderer(typeof(CustomLabel), typeof(CustomLabelRenderer))]
namespace Beanify.Droid.Utils.Renderers
{
    public class CustomLabelRenderer : LabelRenderer
    {

        protected override bool DrawChild(Canvas canvas, Android.Views.View child, long drawingTime)
        {
            return base.DrawChild(canvas, child, drawingTime);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (!string.IsNullOrEmpty(e.NewElement?.StyleId))
            {
                var font = Typeface.CreateFromAsset(Forms.Context.ApplicationContext.Assets, e.NewElement.StyleId + ".ttf");

                Control.Typeface = font;
            }
        }
    }
}