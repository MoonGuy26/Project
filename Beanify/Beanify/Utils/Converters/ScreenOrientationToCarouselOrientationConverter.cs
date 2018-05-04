using Beanify.Utils.Orientation;
using CarouselView.FormsPlugin.Abstractions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace Beanify.Utils.Converters
{
    public class ScreenOrientationToCarouselOrientationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return CarouselView.FormsPlugin.Abstractions.CarouselViewOrientation.Horizontal;
            DeviceOrientations screenOrientation = (DeviceOrientations)value;
            switch (screenOrientation)
            {
                case DeviceOrientations.Undefined:
                    return CarouselView.FormsPlugin.Abstractions.CarouselViewOrientation.Horizontal;
                case DeviceOrientations.Landscape:
                    return CarouselView.FormsPlugin.Abstractions.CarouselViewOrientation.Vertical;
                   
                case DeviceOrientations.Portrait:
                    return CarouselView.FormsPlugin.Abstractions.CarouselViewOrientation.Horizontal;
            }
            return CarouselView.FormsPlugin.Abstractions.CarouselViewOrientation.Horizontal;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return DeviceOrientations.Portrait;
            CarouselViewOrientation carouselOrientation = (CarouselViewOrientation)value;
            switch (carouselOrientation)
            {
                case CarouselViewOrientation.Horizontal:
                    return DeviceOrientations.Portrait;
                case CarouselViewOrientation.Vertical:
                    return DeviceOrientations.Landscape;

            }
            return DeviceOrientations.Portrait;

        }
    }
}
