using Beanify.Utils.Controls;
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
	public partial class OrderReviewView : CustomPage
	{
		public OrderReviewView ()
		{

            NavigationPage.SetBackButtonTitle(this, " ");
            InitializeComponent ();
		}




    }
}