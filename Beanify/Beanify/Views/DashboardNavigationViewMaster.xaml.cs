using Beanify.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Beanify.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DashboardNavigationViewMaster : ContentPage
    {
        public ListView ListView;

        public DashboardNavigationViewMaster()
        {
            InitializeComponent();

            BindingContext = new DashboardNavigationViewModel();
            ListView = MenuItemsListView;
        }

        
    }
}