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
        private IModel _product;
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

        public OrderReviewViewModel(IOrderService orderService) : base()
        {
            _orderService = orderService;
            Commands.Add("Order", new Command(OnOrderExecute));
        }

        public void OnOrderExecute()
        {
            _orderService.AddItem(Order as OrderModel);
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
