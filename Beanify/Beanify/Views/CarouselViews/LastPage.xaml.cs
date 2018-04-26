using Beanify.ViewModels.CarouselViewModels;
using CommonServiceLocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Beanify.Views.CarouselViews
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LastPage : ContentPage, ICarouselable
	{
    
            public LastPage(string textToDisplay, string imgToDisplay)
            {
                InitializeComponent();
                layout.VerticalOptions = LayoutOptions.FillAndExpand;

                text.Text = textToDisplay;
                img.Source = imgToDisplay;

                this.FinalStack = layout;
                this.Content = FinalStack;
            }

            public StackLayout FinalStack { get; set; }
    }
}