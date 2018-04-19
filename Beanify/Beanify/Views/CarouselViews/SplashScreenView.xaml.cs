﻿using Beanify.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms.Xaml;
using Xamarin.Forms;

namespace Beanify.Views.CarouselViews
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SplashScreenView : CarouselPage
	{
		public SplashScreenView ()
		{
			InitializeComponent ();
            BindingContext = new SplashScreenCarouselViewModel(Navigation);
        }
	}
}