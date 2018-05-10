using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Beanify.Utils.Converters
{
    public class OrientationToAspectConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return false;
            StackOrientation orientation = (StackOrientation)value;
            
            if (orientation == StackOrientation.Horizontal)
            {
                return Aspect.AspectFit;
            }
            return Aspect.AspectFill;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
