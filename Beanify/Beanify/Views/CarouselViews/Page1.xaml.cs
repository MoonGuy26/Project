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
            var layout = new StackLayout
            {
                Children = {
                    new Image{  Aspect= Aspect.AspectFit,
                                VerticalOptions =LayoutOptions.EndAndExpand,
                                Source ="@drawable/Lightstart2"},
                    new Label{  VerticalOptions = LayoutOptions.EndAndExpand,
                                Margin = new Thickness(10,10,10,10),
                                Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam sit amet egestas dui, vel ornare justo. Morbi euismod orci id massa iaculis, sit amet auctor justo interdum. Phasellus et nulla orci. Duis volutpat mattis vehicula. Donec lectus sem, suscipit eget tempus luctus, pharetra quis ante. Nulla euismod risus metus, ut volutpat urna auctor vel. Duis sit amet convallis ipsum, placerat pharetra lacus. Aliquam quis tellus sit amet magna luctus fringilla molestie et lectus. Fusce nec mollis lorem.",
                                LineBreakMode = LineBreakMode.WordWrap}
                }
            };
            layout.BackgroundColor = Color.SaddleBrown;
            layout.VerticalOptions = LayoutOptions.FillAndExpand;

            this.FinalStack = layout;

            this.Content = FinalStack;
        }

        public StackLayout FinalStack { get; set; }
    }
}