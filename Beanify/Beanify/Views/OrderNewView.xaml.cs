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

            CustomNavigationPage.SetTitleColor(this, (Color)Application.Current.Resources["TitleWhite"]);

            CustomNavigationPage.SetTitlePosition(this, CustomNavigationPage.TitleAlignment.Center);
            CustomNavigationPage.SetTitleMargin(this, new Thickness(0, 0, 100, 0));
            // CustomNavigationPage.SetTitleFont(this, (Font)Application.Current.Resources["oswald_semibold"]);
            CustomNavigationPage.SetTitleFontType(this, Device.RuntimePlatform == Device.Android ? "oswald_semibold.ttf" : "Oswald SemiBold");
        }


    }
}