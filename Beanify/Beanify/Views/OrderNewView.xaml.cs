using Beanify.Services;
using Beanify.Utils.Controls;
using Beanify.ViewModels;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Beanify.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OrderNewView : CustomPage
	{
        public OrderNewView ()
		{
            NavigationPage.SetBackButtonTitle(this, " ");
			InitializeComponent ();            
		}

        protected override void InitializeNavbar()
        {
            base.InitializeNavbar();
            if (Device.RuntimePlatform == Device.Android)
            {
                Title = "           ";
                CustomNavigationPage.SetTitleFontType(this, "opensans_regular.ttf");
                CustomNavigationPage.SetTitleFontSize(this, 18);
            }
            else
            {
                CustomNavigationPage.SetTitleFontType(this, "Oswald-SemiBold");
            }

            CustomNavigationPage.SetTitleColor(this, (Color)Application.Current.Resources["TitleWhite"]);

            CustomNavigationPage.SetTitlePosition(this, CustomNavigationPage.TitleAlignment.Center);
            CustomNavigationPage.SetTitleMargin(this, new Thickness(0, 0, 100, 0));
            // CustomNavigationPage.SetTitleFont(this, (Font)Application.Current.Resources["oswald_semibold"]);
          
        }


    }
}