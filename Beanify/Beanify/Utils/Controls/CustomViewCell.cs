using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Beanify.Utils.Controls
{
    public class CustomViewCell : ViewCell
    {
        public static readonly BindableProperty SelectedBackgroundColorProperty =
        BindableProperty.Create("SelectedBackgroundColor",
                                typeof(Color),
                                typeof(CustomViewCell),
                                Color.Default);

        public Color SelectedBackgroundColor
        {
            get { return (Color)GetValue(SelectedBackgroundColorProperty); }
            set { SetValue(SelectedBackgroundColorProperty, value); }
        }

        public static readonly BindableProperty IsSelectableProperty =
            BindableProperty.Create("IsSelectable",
                                typeof(bool),
                                typeof(CustomViewCell),
                                true);

        public bool IsSelectable
        {
            get { return (bool)GetValue(IsSelectableProperty); }
            set { SetValue(IsSelectableProperty, value); }
        }
    }
}
