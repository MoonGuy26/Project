using Beanify.Serialization;
using Beanify.ViewModels;
using CommonServiceLocator;
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
	public partial class LoginView : ContentPage
	{
		public LoginView ()
		{
			InitializeComponent ();
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LocalStorageSettings.LastViewModel = nameof(this.GetType) + "Model";
        }
    }
}