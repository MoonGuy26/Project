using Beanify.Models;
using Beanify.Services;
using Beanify.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Beanify.ViewModels
{
    public class OrderReviewViewModel : BaseViewModel
    {

        private IModel _order;

        private IOrderService _orderService;

        public IModel Order
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

        public OrderReviewViewModel(IOrderService orderService) : base()
        {
            _orderService = orderService;
            Commands.Add("Order", new Command(OnOrderExecute));
        }

        public async void OnOrderExecute()
        {
            //await _orderService.AddItem(Order);
            await _orderService.OrderConfirmation(Order);
        }

        public override Task InitializeAsync(object navigationData)
        {
            var order = navigationData as OrderModel;
            Order = order;

            return base.InitializeAsync(navigationData);
        }

    }
}
