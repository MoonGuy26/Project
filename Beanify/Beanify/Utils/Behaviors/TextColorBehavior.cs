using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Beanify.Utils.Behaviors
{
    public static class TextColorBehavior
    {
        public static readonly BindableProperty ApplyTextColorProperty =
            BindableProperty.CreateAttached("ApplyTextColor", typeof(bool), typeof(TextColorBehavior), false,
                propertyChanged: OnApplyTextColorChanged);

        public static readonly BindableProperty TextColorProperty =
            BindableProperty.CreateAttached("TextColor", typeof(Color), typeof(TextColorBehavior), Color.Default);

        public static bool GetApplyTextColor(BindableObject view)
        {
            return (bool)view.GetValue(ApplyTextColorProperty);
        }

        public static void SetApplyTextColor(BindableObject view, bool value)
        {
            view.SetValue(ApplyTextColorProperty, value);
        }

        public static Color GetTextColor(BindableObject view)
        {
            return (Color)view.GetValue(TextColorProperty);
        }

        public static void SetTextColor(BindableObject view, Color value)
        {
            view.SetValue(TextColorProperty, value);
        }

        private static void OnApplyTextColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as View;

            if (view == null)
            {
                return;
            }

            bool hasText = (bool)newValue;

            if (hasText)
            {
                SetTextColor(view, Color.OrangeRed);
            }
            else
            {
                
            }
        }
    }
}
