using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Beanify.Utils.Converters
{
    public class FloatToPriceConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return false;
            var str = "£" + ((float)value).ToString("n2");
            if (parameter != null && Boolean.Parse(parameter.ToString()))
            {
                Regex reg = new Regex(@"[,.]00");
                if (reg.IsMatch(str))
                    return str.Remove(str.Length - 3);
            }
            return str;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

