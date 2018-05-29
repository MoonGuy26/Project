﻿using Beanify.Models;
using Beanify.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Beanify.ViewModels
{
    public class OrderNewViewModel : BaseViewModel
    {
        private IAccountService _accountService;

        private int _quantity;

        public int Quantity
        {
            get { return _quantity; }
            set
            {
                if (_quantity != value)
                {
                    _quantity = value;
                    OnPropertyChanged(nameof(Quantity));
                }
            }
        }

        private ProductModel _productModel;

        public ProductModel ProductModel
        {
            get { return _productModel; }
            set
            {
                if (_productModel != value)
                {
                    _productModel = value;
                    OnPropertyChanged(nameof(ProductModel));
                }
            }
        }

        public OrderNewViewModel(IAccountService accountService) : base()
        {
            _accountService = accountService;
            Commands.Add("Continue", new Command(OnContinueExecute));
            Commands.Add("Plus", new Command(OnPlusExecute));
            Commands.Add("Minus", new Command(OnMinusExecute));
        }

        public async void OnContinueExecute() {
            await NavigateOrderReviewView();
        }
        
        public void OnPlusExecute()
        {
                Quantity++;
        }

        public void OnMinusExecute()
        {
            if ( Quantity != 0)
                Quantity--;
        }

        private async Task NavigateOrderReviewView()
        {
            var orderModel = new OrderModel
            {
                ProductModelId = ProductModel.Id,
                ProductName = ProductModel.Name,
                Price = _productModel.Price * (_quantity),
                Quantity = _quantity,
                
                IsNew = true,
                
            };
            var object_list = new List<object>();
            object_list.Add(_productModel);
            object_list.Add(orderModel);


            await _navigationService.NavigateToInsideDashboardAsync<OrderReviewViewModel>(object_list);
        }


        public override Task InitializeAsync(object navigationData)
        {

            ProductModel = (navigationData as ProductModel);

            return Task.FromResult(true);
        }



    }
}
