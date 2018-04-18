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
	public partial class Page1 : ContentPage, ICarouselable
	{
		public Page1 ()
		{
			InitializeComponent();

            //layout.BackgroundColor = Color.SaddleBrown;
            //layout.VerticalOptions = LayoutOptions.FillAndExpand;

            this.FinalStack = layout;

            this.Content = FinalStack;
        }

        public StackLayout FinalStack { get; set; }
    }
}