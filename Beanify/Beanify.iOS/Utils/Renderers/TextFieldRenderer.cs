using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Beanify.iOS.Utils.Renderers;
using Beanify.Utils.Controls;
using CoreGraphics;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(TextFieldRenderer))]
namespace Beanify.iOS.Utils.Renderers
{
    public class TextFieldRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                var view = (CustomEntry)Element;

                Control.LeftView = new UIView(new CGRect(0f, 0f, 9f, 20f));

                Control.LeftViewMode = UITextFieldViewMode.Always;
                Control.KeyboardAppearance = UIKeyboardAppearance.Dark;
                Control.ReturnKeyType = UIReturnKeyType.Done;
                Control.BackgroundColor = view.FieldBgColor.ToUIColor();
                //Control.Layer.CornerRadius = 8;
                Control.Layer.BorderColor = view.BorderColor.ToCGColor();
                Control.Layer.BorderWidth = view.BorderWidth;
                Control.BorderStyle= UITextBorderStyle.RoundedRect;

                Control.ClipsToBounds = true;
            }

        }

    }
}