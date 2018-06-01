using System;
using System.Globalization;
using Xamarin.Forms;

namespace Beanify.Utils.Converters
{
    public class OrientationToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return false;
            StackOrientation orientation = (StackOrientation)value;
            if (parameter != null)
            {
                bool inverted = (bool)parameter;
                if (orientation == StackOrientation.Horizontal)
                {
                    return parameter;
                }

            }
            if (orientation==StackOrientation.Horizontal)
            {
                return false;
            }
            return true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
