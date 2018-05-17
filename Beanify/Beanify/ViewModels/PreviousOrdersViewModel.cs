using Beanify.Models;
using Beanify.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Beanify.ViewModels
{
    public class PreviousOrdersViewModel : BaseViewModel
    {
        public ObservableCollection<OrderModel> Orders
        {
            get; set;
        }

        public PreviousOrdersViewModel(IOrderService OrderService) : base()
        {
            OrderService orderService = (OrderService)OrderService;
            Orders = new ObservableCollection<OrderModel>(orderService.GetOrder());

            /*Orders = new ObservableCollection<OrderModel>
            {
               new OrderModel {
                               ProductName = "azerty", Date = DateTime.Now , Quantity = 12,
                           },
               new OrderModel {
                               ProductName = "azerty", Date = DateTime.Now , Quantity = 12,
                           },
               new OrderModel {
                               ProductName = "azerty", Date = DateTime.Now , Quantity = 12,
                           },
               new OrderModel {
                               ProductName = "azerty", Date = DateTime.Now , Quantity = 12,
                           },
               new OrderModel {
                               ProductName = "azerty", Date = DateTime.Now , Quantity = 12,
                           },
               new OrderModel {
                               ProductName = "azerty", Date = DateTime.Now , Quantity = 12,
                           },
               new OrderModel {
                               ProductName = "azerty", Date = DateTime.Now , Quantity = 12,
                           },
               new OrderModel {
                               ProductName = "azerty", Date = DateTime.Now , Quantity = 12,
                           },
               new OrderModel {
                               ProductName = "azerty", Date = DateTime.Now , Quantity = 12,
                           },
               new OrderModel {
                               ProductName = "azerty", Date = DateTime.Now , Quantity = 12,
                           },
               new OrderModel {
                               ProductName = "azerty", Date = DateTime.Now , Quantity = 12,
                           },
               new OrderModel {
                               ProductName = "azerty", Date = DateTime.Now , Quantity = 12,
                           },
               new OrderModel {
                               ProductName = "azerty", Date = DateTime.Now , Quantity = 12,
                           },
               new OrderModel {
                               ProductName = "azerty", Date = DateTime.Now , Quantity = 12,
                           },
               new OrderModel {
                               ProductName = "azerty", Date = DateTime.Now , Quantity = 12,
                           },
               new OrderModel {
                               ProductName = "azerty", Date = DateTime.Now , Quantity = 12,
                           },
           };*/
        }
    }
}
