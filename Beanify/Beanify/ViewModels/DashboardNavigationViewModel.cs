using Beanify.Models;
using Beanify.Serialization;
using Beanify.Services;
using Beanify.Utils.Navigation;
using Beanify.Views;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using Xamarin.Forms;

namespace Beanify.ViewModels
{
    public class DashboardNavigationViewModel : BaseViewModel
    {
        private List<ProductModel> _products;

        private bool _triggerEvent = true;
        private DashboardNavigationViewMenuItem _selectedItem;
        private Page _detailPage;

        private DashboardNavigationViewMenuItem _previousSelectedItem;

        private IProductService _productService;

        public List<ProductModel> Products
        {

            get { return _products; }
            set
            {
                if (_products != value)
                {
                    _products = value;
                    OnPropertyChanged(nameof(Products));
                }
            }
        }

        public DashboardNavigationViewMenuItem SelectedItem
        {
            get { return _selectedItem; }
            set {
                if (_selectedItem != value)
                {
                    if ( _selectedItem == null)
                    {
                        _previousSelectedItem = MenuItems[0];
                    }
                    else _previousSelectedItem = _selectedItem;
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

        public DashboardNavigationViewModel(IProductService ProductService,INavigationService navigationService) : base(navigationService)
        {
            Products = new List<ProductModel>();
            _productService = ProductService;

            Thread thread = new Thread(new ThreadStart(AsynchronousTask));
            thread.IsBackground = true;
            thread.Start();

        }

        private void AsynchronousTask()
        {
            Products = _productService.GetProducts();
        }
    

        override protected void InitializeViewModel()
        {
            base.InitializeViewModel();
            MenuItems = new ObservableCollection<DashboardNavigationViewMenuItem>(new[]
            {
                    new DashboardNavigationViewMenuItem { Id = 0, Title = "Dashboard",Icon="dashboard_ic",
                    OnClicked =OnDashboardExecute},
                    new DashboardNavigationViewMenuItem { Id = 1, Title = "Place Order",Icon="products_ic",
                    OnClicked =OnPlaceOrderExecute},
                    new DashboardNavigationViewMenuItem { Id = 2, Title = "My Previous Orders",Icon="orders_ic",
                    OnClicked =OnPreviousOrderExecute },
                    new DashboardNavigationViewMenuItem { Id = 3, Title = "Log out",Icon="logout_ic",
                    OnClicked =OnLogoutExecute },
                    
                   
                });
            if(Device.RuntimePlatform==Device.iOS)
                _selectedItem = MenuItems[0];
            
            _previousSelectedItem = MenuItems[0];
            
            Commands.Add("ItemSelected", new Command(ItemSelectedExecute));

            SubscribeToMessages();

        }

        private void SubscribeToMessages()
        {
            MessagingCenter.Subscribe<DashboardViewModel>(this, "NavigateToPlaceOrder", (sender) =>
            {
                SelectedItem = MenuItems[1];
                OnPlaceOrderExecute();
            });
            MessagingCenter.Subscribe<LogoutPopUpViewModel>(this, "TriggerNavigation", (sender) =>
            {
                _triggerEvent = true;
            });
        }


        private void ItemSelectedExecute()
        {
            if(_triggerEvent)
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
            _navigationService.NavigateToDashboardAsync<ProductsViewModel>(Products);
        }

        private void OnLogoutExecute()
        {
            //Application.Current.MainPage = new CustomNavigationView(new LoginView() as Page);

            //LocalStorageSettings.AccessToken = null;
            //((App)Application.Current).MainPage = new Views.LoginView();
            _triggerEvent = false;
            if (_previousSelectedItem!=null)
                SelectedItem = _previousSelectedItem;
            
           PopupNavigation.Instance.PushAsync(new LogoutPopUpView());
           
        }

        
    }
}
