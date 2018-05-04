using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Beanify.Utils.UI
{
    public class CarouselDotsControl
    {
        private ObservableCollection<CarouselDot> _dots;
        private int _lastCurrent = 0;
        
        public ObservableCollection<CarouselDot> Dots
        {
            get { return _dots; }
            set { _dots = value; }
        }

        public CarouselDotsControl(int dotsNumber)
        {
            Dots = new ObservableCollection<CarouselDot>();
            for (int i = 0; i < dotsNumber; i++)
            {
                Dots.Add(new CarouselDot());
            }
        }

        public void SelectDot(int index)
        {
            Dots[_lastCurrent].UnsetAsCurrent();
            Dots[index].SetAsCurrent();
            _lastCurrent = index;
        }

    }
}
