using Beanify.Utils.Controls;
using Beanify.ViewModels;
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
	public partial class DashboardView : CustomPage
	{
		public DashboardView ()
		{
            CustomNavigationPage.SetTitleColor(this, Color.Transparent);
            CustomNavigationPage.SetTitleBackground(this, "logo_sm");
            
            CustomNavigationPage.SetTitlePosition(this, CustomNavigationPage.TitleAlignment.Center);
            CustomNavigationPage.SetTitleMargin(this, new Thickness(0, 0, 100, 0));
            InitializeComponent();
        }
	}
}