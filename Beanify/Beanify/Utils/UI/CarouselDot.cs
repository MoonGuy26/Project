using Beanify.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beanify.Utils.UI
{
    public class CarouselDot:ObservableProperty
    {
        private string _imageSource;
        private bool _isCurrent;

        public bool IsCurrent
        {
            get { return _isCurrent; }
            set { _isCurrent = value; }
        }


        public string ImagesSource
        {
            get { return _imageSource; }
            set { _imageSource = value;
                OnPropertyChanged(nameof(ImagesSource));
            }
        }

        public CarouselDot()
        {
            ImagesSource = "@drawable/unselected_circle.png";
        }

        public void SetAsCurrent()
        {
            IsCurrent = true;
            ImagesSource = "@drawable/selected_circle.png";
        }

        public void UnsetAsCurrent()
        {
            IsCurrent = false;
            ImagesSource = "@drawable/unselected_circle.png";
        }
    }
}
