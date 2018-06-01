using Beanify.ViewModels;

namespace Beanify.Models
{
    public class CarouselPageModel : ObservableProperty
    {
        private string _imagePath;
        private string _text;

        public string ImagePath { get => _imagePath; set
            {
                _imagePath = value;
                OnPropertyChanged(nameof(ImagePath));
            }
        }
        public string Text { get => _text; set
            {
                _text = value;
                OnPropertyChanged(nameof(Text));
            }
        }

    }
}
