﻿using Beanify.Models;
using Beanify.Services;
using Beanify.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Beanify.ViewModels
{
    public class ProductsViewModel : BaseViewModel
    {
        private ObservableCollection<ProductModel> _products;

        public ObservableCollection<ProductModel> Products
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



        private ProductService _productService;

        public ProductsViewModel(IProductService ProductService) : base()
        {
            _productService = (ProductService)ProductService;

            Thread thread = new Thread(new ThreadStart(AsynchronousTask));
            thread.IsBackground = true;
            thread.Start();
            
            // Problem has been identified : It should be run-away tasks issues, so, it means that the UI is lock due to this run-away tasks
            // https://blog.xamarin.com/getting-started-with-async-await/ - Here is a nice tutorial to get rid of it.

            Commands.Add("LoadingDetails", OnMoreInfoExecute);
        }

        private void AsynchronousTask()
        {
            Products = new ObservableCollection<ProductModel>(_productService.GetProducts());
            Debug.WriteLine((Products).ToString());
        }

        private Command<object> _OnMoreInfoExecute;

        public  Command<object> OnMoreInfoExecute
        {
            get { return _OnMoreInfoExecute ?? (_OnMoreInfoExecute = new Command<object>((currentObject) => NavigateToInfo(currentObject))); }
        }

        private async void NavigateToInfo(object currentObject)
        {
            await _navigationService.NavigateToInsideDashboardAsync<OrderNewViewModel>((ProductModel)currentObject);
        }
  
    }
}