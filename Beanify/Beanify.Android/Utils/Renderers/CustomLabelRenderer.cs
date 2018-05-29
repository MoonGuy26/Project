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
using Android.Graphics.Drawables;
using Android.Util;



[assembly: ExportRenderer(typeof(CustomLabel), typeof(CustomLabelRenderer))]
namespace Beanify.Droid.Utils.Renderers
{
    public class CustomLabelRenderer : LabelRenderer
    {

        public CustomLabelRenderer(Context context) : base(context) { }

        private GradientDrawable _gradientBackground;
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            var view = (CustomLabel)Element;
            if (view == null) return;
            // creating gradient drawable for the curved background  
            _gradientBackground = new GradientDrawable();
            _gradientBackground.SetShape(ShapeType.Oval);

            // Thickness of the stroke line  
            _gradientBackground.SetStroke(10, view.CornerBackgroundColor.ToAndroid());

            Control.SetBackground(_gradientBackground);
            Control.SetMinWidth((int)DpToPixels(this.Context, Convert.ToSingle(50)));
            Control.SetMinHeight((int)DpToPixels(this.Context, Convert.ToSingle(50)));
            Control.SetHeight((int)DpToPixels(this.Context, Convert.ToSingle(Control.Width)));
            Control.SetPadding(
                        (int)DpToPixels(this.Context, Convert.ToSingle(5)), 
                        (int)DpToPixels(this.Context, Convert.ToSingle(5)), 
                        (int)DpToPixels(this.Context, Convert.ToSingle(5)), 
                        (int)DpToPixels(this.Context, Convert.ToSingle(5)));
            
        }
        //Px to Dp Conver  
        public static float DpToPixels(Context context, float valueInDp)
        {
            DisplayMetrics metrics = context.Resources.DisplayMetrics;
            return TypedValue.ApplyDimension(ComplexUnitType.Dip, valueInDp, metrics);
        }
    }
}

