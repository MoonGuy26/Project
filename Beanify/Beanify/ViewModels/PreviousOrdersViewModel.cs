using Beanify.Models;
using Beanify.Services;
using Beanify.Utils.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Beanify.ViewModels
{
    public class PreviousOrdersViewModel : BaseViewModel
    {
        private IOrderService _orderService;

        public ObservableCollection<AppOrderModel> Orders
        {
            get; set;
        }

        public PreviousOrdersViewModel(IOrderService OrderService,INavigationService navigationService) :base(navigationService) 
        {
            _orderService= OrderService;
            LoadOrders();

            
        }

        private void LoadOrders()
        {
            Orders = new ObservableCollection<AppOrderModel>(_orderService.GetOrders());
        }
    }
}
