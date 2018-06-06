using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Beanify.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomeCarouselView : ContentPage
	{
		public HomeCarouselView ()
		{
			InitializeComponent ();
		}

        /* Useless since landscape landscape is disabled on the whole app
        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Send(this, "preventLandScape"); 
        }
        //during page close setting back to portrait
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Send(this, "allowLandScapePortrait");
            
        }*/
    }
}