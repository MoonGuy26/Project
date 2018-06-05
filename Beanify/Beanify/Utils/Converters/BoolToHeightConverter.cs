using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Beanify.Utils.Converters
{
    public class BoolToHeightConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return 180;
            if (value.GetType() != typeof(bool))
            {
                return 180;
            }
            var isFirst = (bool)value;
            if (isFirst) return 210;
            return 180;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
