﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Beanify.Views.CarouselViews
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SimplePage : ContentPage, ICarouselable
    {
        public SimplePage(string textToDisplay, string imgToDisplay)
        {
            InitializeComponent();

            layout.BackgroundColor = Color.SaddleBrown;
            layout.VerticalOptions = LayoutOptions.FillAndExpand;


            text.Text = textToDisplay;
            img.Source = imgToDisplay;

            this.FinalStack = layout;

            this.Content = FinalStack;
        }

        public StackLayout FinalStack { get; set; }
    }
}