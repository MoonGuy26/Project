using Beanify.Models;
using Beanify.Utils.Orientation;
using Beanify.Utils.UI;
using Beanify.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Beanify.ViewModels
{
    public class HomeCarouselViewModel : BaseViewModel
    {


        private ObservableCollection<View> _carouselPages;
            
        public ObservableCollection<View> CarouselPages
        {
            get { return _carouselPages; }
            set {
                _carouselPages = value;
                OnPropertyChanged(nameof(CarouselPages));
            }
        }

        
        

        public HomeCarouselViewModel()
        {
            CarouselPages = new ObservableCollection<View>();
            CarouselPages.Add(new HomePageView());
            CarouselPages.Add(new HomePageView());
            CarouselPages.Add(new ButtonHomePageView());
            
            
        }

        override protected void InitializeViewModel()
        {
            base.InitializeViewModel();

         

        }

        
    }
}
