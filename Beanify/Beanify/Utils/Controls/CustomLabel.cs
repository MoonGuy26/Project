using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Beanify.Utils.Controls
{
    public class CustomLabel : Label 
    {
        public static readonly BindableProperty CornerRadiusProperty =  
            BindableProperty.Create(  
                nameof(CornerRadius),  
                typeof(double),  
                typeof(CustomLabel),  
                50.0);  
  
      public double CornerRadius  
      {  
          get { return (double)GetValue(CornerRadiusProperty); }  
          set { SetValue(CornerRadiusProperty, value); }  
      }  
  
      public static readonly BindableProperty CornerBackgroundColorProperty =  
          BindableProperty.Create(  
              nameof(CornerBackgroundColor),  
              typeof(Color),  
              typeof(CustomLabel),  
              Color.Default);  
  
      public Color CornerBackgroundColor  
      {  
          get { return (Color)GetValue(CornerBackgroundColorProperty); }  
          set { SetValue(CornerBackgroundColorProperty, value); }  
      }  
    }
}
