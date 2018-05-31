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


    }
}