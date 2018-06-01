using Beanify.iOS.Utils.Renderers;
using Beanify.Utils.Controls;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

//[assembly: ExportRenderer(typeof(CustomLabel), typeof(CustomLabelRenderer))]  
namespace Beanify.iOS.Utils.Renderers
{
    public class CustomLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                var _xfViewReference = (CustomLabel)Element;

                

                this.Layer.CornerRadius = (float)_xfViewReference.CornerRadius;
                this.Layer.BorderColor = _xfViewReference.CornerBackgroundColor.ToCGColor();
                this.Layer.BorderWidth = 10;
            }
        }
    }
}