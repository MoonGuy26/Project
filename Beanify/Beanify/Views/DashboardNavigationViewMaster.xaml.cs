using Beanify.Utils.Controls;
using Beanify.ViewModels;
using CommonServiceLocator;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Beanify.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashboardNavigationViewMaster : CustomPage
    {
        public ListView ListView;

        public DashboardNavigationViewMaster()
        {
            InitializeComponent();

            BindingContext = ServiceLocator.Current.GetInstance<DashboardNavigationViewModel>();
            ListView = MenuItemsListView;


           
        }

        protected override void InitializeNavbar()
        {
            base.InitializeNavbar();
            if (Device.RuntimePlatform==Device.iOS)
            {
                CustomNavigationPage.SetTitleVisible(this, true);
            }
            CustomNavigationPage.SetTitleMargin(this, new Thickness(20, 0, 0, 0));
        }



    }
}