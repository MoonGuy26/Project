using Beanify.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Beanify
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            //MainPage = new NavigationPage(new Views.CarouselViews.SplashScreenView());
            SetMainPage();
        }

        private void SetMainPage()
        {
            if (!string.IsNullOrEmpty(LocalStorageSettings.AccessToken))
            {
                MainPage = new NavigationPage(new Views.DashboardView());
            }
            else
            { 
                MainPage = new NavigationPage(new Views.CarouselViews.CustomCarouselPage());
            }

        }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
