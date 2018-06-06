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
    public partial class DashboardNavigationView : MasterDetailPage
    {
        public DashboardNavigationView()
        {
            InitializeComponent();
            //if (Device.OS == TargetPlatform.iOS)
            //{
            //    var toolbarItem = new ToolbarItem();
            //    toolbarItem.Icon = "cup_ic.png";
            //    toolbarItem.Order = ToolbarItemOrder.Primary;

            //    toolbarItem.Activated += MenuClicked;

            //    var toolbarSpace = new ToolbarItem();
            //    toolbarSpace.Icon = "transparent.png";
            //    ToolbarItems.Add(toolbarItem);
            //    ToolbarItems.Add(toolbarSpace);
            //    ToolbarItems.Add(toolbarSpace);
            //    ToolbarItems.Add(toolbarSpace);
            //    ToolbarItems.Add(toolbarSpace);
            //    ToolbarItems.Add(toolbarSpace);
            //    ToolbarItems.Add(toolbarSpace);
            //    ToolbarItems.Add(toolbarSpace);
            //    ToolbarItems.Add(toolbarSpace);
            //    ToolbarItems.Add(toolbarSpace);
            //    ToolbarItems.Add(toolbarSpace);
            //    ToolbarItems.Add(toolbarSpace);

            //}
            
        }
        private void MenuClicked(object sender, EventArgs e)
        {
            IsPresented = true;
        }
        
    }
}