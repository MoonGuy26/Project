using Beanify.Models;
using Beanify.Services;
using Beanify.Utils.Navigation;
using Beanify.Views;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Beanify.ViewModels
{
    public class OrderReviewViewModel : BaseViewModel
    {
        private IModel _product;
        private OrderModel _order;
        private IOrderService _orderService;

        public OrderModel Order
        {
            get { return _order; }
            set {
                if(_order != value)
                {
                    _order = value;
                    OnPropertyChanged(nameof(Order));
                }
            }
        }

        public IModel Product
        {
            get { return _product; }
            set
            {
                if (_product != value)
                {
                    _product = value;
                    OnPropertyChanged(nameof(Product));
                }
            }
        }

        public OrderReviewViewModel(IOrderService orderService,INavigationService navigationService) :base(navigationService)
        {
            _orderService = orderService;
            Commands.Add("Order", new Command(OnOrderExecute));
        }


        private async void OnOrderExecute()
        {
            await OrderAndBackToProducts();
        }

        private async Task OrderAndBackToProducts()
        {
            try
            {
                Order.ApplicationUserId = "default";
                Order.CompanyName = "default";
                Order.CustomerName = "default";
                Order.Date = DateTime.Now;
                
                _orderService.AddItem(Order);
                PopupPage popup = new CallBackPopupView();
                _navigationService.NavigateToDashboardAsync<DashboardViewModel>();
                await (popup.BindingContext as BaseViewModel).InitializeAsync("Thank you for ordering, you will receive an email shortly confirming your order");
                await PopupNavigation.Instance.PushAsync(popup);
                
            }
            catch (Exception e)
            {
                PopupPage popup = new ErrorPopupView();
                await PopupNavigation.Instance.PushAsync(popup);
                var errorMessage = e.Message;
                if(e.Message.Equals("One or more errors occurred."))
                {
                    errorMessage = "An error has occurred during the ordering proccess. No order has been made.";
                }
                await (popup.BindingContext as BaseViewModel).InitializeAsync(errorMessage);
            }
        }

        public void OnExecuteResult(bool choice)
        {
            if (choice)
            {
                _orderService.AddItem(Order);
            }
                       
        }

        public override Task InitializeAsync(object navigationData)
        {
            var objectList = navigationData as List<object>;
            Product = objectList[0] as ProductModel;
            Order = objectList[1] as OrderModel;

            return base.InitializeAsync(navigationData);
        }

    }
}
