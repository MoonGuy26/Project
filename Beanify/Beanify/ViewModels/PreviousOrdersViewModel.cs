using Beanify.Models;
using Beanify.Services;
using Beanify.Utils.Navigation;
using Beanify.Views;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Beanify.ViewModels
{
    public class PreviousOrdersViewModel : BaseViewModel
    {
        private IOrderService _orderService;

        private ObservableCollection<AppOrderModel> _orders;

        public ObservableCollection<AppOrderModel> Orders
        {
            get
            {
                return _orders;
            }
            set
            {
                if (value != _orders)
                {
                    _orders = value;
                    OnPropertyChanged(nameof(Orders));
                }
            }
        }

        public PreviousOrdersViewModel(IOrderService OrderService,INavigationService navigationService) :base(navigationService) 
        {
            _orderService= OrderService;
        }

        public override Task InitializeAsync(object navigationData)
        {
            try
            {
                LoadOrders();
            }
            catch(Exception e)
            {  
                PopupPage popup = new CallBackPopupView();
                var errorMessage = e.Message;

                (popup.BindingContext as BaseViewModel).InitializeAsync(errorMessage);
                (popup.BindingContext as BaseViewModel).InitializeAsync(true);
                PopupNavigation.Instance.PushAsync(popup);
                
            }
            return base.InitializeAsync(navigationData);
        }

        private void LoadOrders()
        {
            var orderList = _orderService.GetOrders();
            orderList[0].IsFirst = true;
            Orders = new ObservableCollection<AppOrderModel>(orderList);
            
        }
    }
}
