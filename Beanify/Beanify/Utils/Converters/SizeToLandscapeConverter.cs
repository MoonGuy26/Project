using Beanify.Utils.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Beanify.Utils.Converters
{
    public class SizeToLandscapeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            if (value == null)
                return false;
            ScreenDimensions dimensions = (ScreenDimensions)value;

            if (dimensions.ScreenHeight > dimensions.ScreenWidth)
            {
                return dimensions.ScreenWidth;
            }
            else
                return dimensions.ScreenWidth/2; 

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
