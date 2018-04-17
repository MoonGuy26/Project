using Beanify.ViewModels.CarouselViewModels;
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
	public partial class Page3 : ContentPage
	{
    
            public Page3()
            {
                InitializeComponent();
                BindingContext = new Page3viewModel(Navigation);

                /*
                Grid grid = new Grid();
                RowDefinition row1 = new RowDefinition();
                RowDefinition row2 = new RowDefinition();
                RowDefinition row3 = new RowDefinition();
                row1.Height = new GridLength(60);
                row2.Height = new GridLength(40);
                row3.Height = new GridLength(40);
                grid.RowDefinitions.Add(row1);
                grid.RowDefinitions.Add(row2);
                grid.RowDefinitions.Add(row3);

                Image img1 = new Image
                {
                    Aspect = Aspect.AspectFit,
                    VerticalOptions = LayoutOptions.EndAndExpand,
                    Source = "@drawable/Lightstart2"
                };

                Label lb = new Label
                {
                    VerticalOptions = LayoutOptions.EndAndExpand,
                    Margin = new Thickness(10, 10, 10, 10),
                    Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam sit amet egestas dui, vel ornare justo. Morbi euismod orci id massa iaculis, sit amet auctor justo interdum. Phasellus et nulla orci. Duis volutpat mattis vehicula. Donec lectus sem, suscipit eget tempus luctus, pharetra quis ante. Nulla euismod risus metus, ut volutpat urna auctor vel. Duis sit amet convallis ipsum, placerat pharetra lacus. Aliquam quis tellus sit amet magna luctus fringilla molestie et lectus. Fusce nec mollis lorem.",
                    LineBreakMode = LineBreakMode.WordWrap
                };

                Button btn = new Button
                {
                    Text = "Ok",
                    //Command = SetBinding(Button.CommandProperty,  new Binding ("LoginCommand", 0));

                };*/
                /*
                var layout = new StackLayout
                {
                    Children = {
                    new Image{  Aspect= Aspect.AspectFit,
                                VerticalOptions =LayoutOptions.EndAndExpand,
                                Source ="@drawable/Lightstart2"},
                    new Label{  VerticalOptions = LayoutOptions.EndAndExpand,
                                Margin = new Thickness(10,10,10,10),
                                Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aliquam sit amet egestas dui, vel ornare justo. Morbi euismod orci id massa iaculis, sit amet auctor justo interdum. Phasellus et nulla orci. Duis volutpat mattis vehicula. Donec lectus sem, suscipit eget tempus luctus, pharetra quis ante. Nulla euismod risus metus, ut volutpat urna auctor vel. Duis sit amet convallis ipsum, placerat pharetra lacus. Aliquam quis tellus sit amet magna luctus fringilla molestie et lectus. Fusce nec mollis lorem.",
                                LineBreakMode = LineBreakMode.WordWrap},
                    new Button {    Text = "Ok",
                                    //Command = SetBinding(Button.CommandProperty,  new Binding ("LoginCommand", 0));
                                
                    }

                }
                };
                layout.BackgroundColor = Color.SaddleBrown;
                layout.VerticalOptions = LayoutOptions.FillAndExpand;

                this.FinalStack = layout;

                this.Content = FinalStack;*/
            }

            //public StackLayout FinalStack { get; set; }
    }
}