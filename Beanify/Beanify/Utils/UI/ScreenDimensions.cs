using Beanify.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beanify.Utils.UI
{
    public class ScreenDimensions : ObservableProperty
    {
        private double _screenWidth;
        private double _screenHeight;

        public double ScreenWidth
        {
            get { return _screenWidth; }
            set
            {
                _screenWidth = value;
                OnPropertyChanged(nameof(ScreenWidth));
            }
        }
        public double ScreenHeight
        {
            get { return _screenHeight; }
            set
            {
                _screenHeight = value;
                OnPropertyChanged(nameof(ScreenHeight));
            }
        }

    }
}
