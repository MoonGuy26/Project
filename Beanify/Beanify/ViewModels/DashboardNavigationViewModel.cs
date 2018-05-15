using Beanify.Models;
using Beanify.Serialization;
using Beanify.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Beanify.ViewModels
{
    public class DashboardNavigationViewModel : BaseViewModel
    {

        private DashboardNavigationViewMenuItem _selectedItem;
        private Page _detailPage;

        


        public DashboardNavigationViewMenuItem SelectedItem
        {
            get { return _selectedItem; }
            set {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                    OnPropertyChanged(nameof(SelectedItem));
                }
            }
        }

        public Page DetailPage
        {
            get { return _detailPage; }
            set { _detailPage = value; }
        }

        public ObservableCollection<DashboardNavigationViewMenuItem> MenuItems { get; set; }

        

        override protected void InitializeViewModel()
        {
            base.InitializeViewModel();
            MenuItems = new ObservableCollection<DashboardNavigationViewMenuItem>(new[]
            {
                    new DashboardNavigationViewMenuItem { Id = 0, Title = "Dashboard",Icon="md-home",
                    OnClicked =OnDashboardExecute},
                    new DashboardNavigationViewMenuItem { Id = 1, Title = "Place Order",Icon="md-shopping-cart",
                    OnClicked =OnPlaceOrderExecute},
                    new DashboardNavigationViewMenuItem { Id = 2, Title = "My Previous Orders",Icon="md-free-breakfast",
                    OnClicked =OnPreviousOrderExecute },
                    new DashboardNavigationViewMenuItem { Id = 3, Title = "Log out",Icon="md-input",
                    OnClicked =OnLogoutExecute },
                    
                   
                });
            Commands.Add("ItemSelected", new Command(ItemSelectedExecute));
            
        }


        private void ItemSelectedExecute()
        {
            _selectedItem.OnClicked?.Invoke();
        }

        private void OnDashboardExecute()
        {
            _navigationService.NavigateToDashboardAsync<DashboardViewModel>();
        }

        private void OnPreviousOrderExecute()
        {
            _navigationService.NavigateToDashboardAsync<PreviousOrdersViewModel>();

        }

        private void OnPlaceOrderExecute()
        {
            _navigationService.NavigateToDashboardAsync<ProductsViewModel>();
        }

        private void OnLogoutExecute()
        {
            LocalStorageSettings.AccessToken = null;
            //Application.Current.MainPage = new CustomNavigationView(new LoginView() as Page);
            ((App)Application.Current).MainPage = new Views.LoginView();

        }

        
    }
}
