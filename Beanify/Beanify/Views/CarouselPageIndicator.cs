using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Beanify.Views
{
    public class CarouselPageIndicator : StackLayout
    {
        public CarouselPageIndicator(int currentIndex, int totalItems, string sourceIndicator, string souceEmptyIndicator)
        {
            this.Orientation = StackOrientation.Horizontal;
            this.HorizontalOptions = LayoutOptions.CenterAndExpand;

            for (int i = 0; i < totalItems; i++)
            {
                var image = new Image();

                if (i == currentIndex)
                    image.Source = sourceIndicator;
                else
                    image.Source = souceEmptyIndicator;

                this.Children.Add(image);
            }

            this.Padding = new Thickness(10);
        }
    }
}
