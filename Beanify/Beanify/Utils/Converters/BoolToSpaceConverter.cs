using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Beanify.Utils.Converters
{
    public class BoolToSpaceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return new Thickness(10,0,10,0);
            if (value.GetType() != typeof(bool))
            {
                return new Thickness(10, 0, 10, 0);
            }
            var isFirst = (bool)value;
            if(isFirst) return new Thickness(10, 30, 10, 0);
            return new Thickness(10, 0, 10, 0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
