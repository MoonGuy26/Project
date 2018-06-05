using Beanify.Models;
using Beanify.Services;
using Beanify.Utils.Navigation;
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

        private IProductService _productService;

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



        

        public ProductsViewModel(IProductService ProductService,INavigationService navigationService) :base(navigationService)
        {
            Products = new ObservableCollection<ProductModel>();
            _productService = ProductService;

            
            
            // Problem has been identified : It should be run-away tasks issues, so, it means that the UI is lock due to this run-away tasks
            // https://blog.xamarin.com/getting-started-with-async-await/ - Here is a nice tutorial to get rid of it.

            Commands.Add("LoadingDetails", OnMoreInfoExecute);
        }

        private void AsynchronousTask()
        {
            var productsList = _productService.GetProducts();
            productsList[0].IsFirst = true;
            Products = new ObservableCollection<ProductModel>(productsList);
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

        public override Task InitializeAsync(object navigationData)
        {
            if (navigationData != null)
            {
                var productList = navigationData as List<ProductModel>;
                productList[0].IsFirst = true;
                Products = new ObservableCollection<ProductModel>(productList);
               
            }
            else
            {
                Thread thread = new Thread(new ThreadStart(AsynchronousTask));
                thread.IsBackground = true;
                thread.Start();
            }
            
            return base.InitializeAsync(navigationData);
        }

    }
}