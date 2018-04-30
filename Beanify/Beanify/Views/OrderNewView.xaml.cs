using Beanify.Services;
using Beanify.ViewModels;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Beanify.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OrderNewView : ContentPage
	{
        public OrderNewView ()
		{
			InitializeComponent ();            
		}
    }
}