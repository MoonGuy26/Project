using Beanify.Models;
using Beanify.Services;
using Beanify.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Beanify.ViewModels
{
    public class ProductsViewModel : BaseViewModel
    {

        public ObservableCollection<ProductsModel> Categ
        {
            get; set;
        }

        public ObservableCollection<ProductModel> Products
        {
            get; set;
        }
        public ProductModel _selectedItem;
        public ProductModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (_selectedItem != value && value != null)
                {
                    if (_selectedItem != null){}
                    _selectedItem = value;                   
                    OnPropertyChanged(nameof(SelectedItem));
                }
            }
        }

        public ProductsViewModel(IProductService ProductService) : base()
        {

            ProductService productService = (ProductService)ProductService;
            Products = new ObservableCollection<ProductModel>(productService.GetProducts());
            
            // Problem has been identified : It should be run-away tasks issues, so, it means that the UI is lock due to this run-away tasks
            // https://blog.xamarin.com/getting-started-with-async-await/ - Here is a nice tutorial to get rid of it.

            Commands.Add("LoadingDetails", new Command(OnMoreInfoExecute));
            /*Categ = new ObservableCollection<ProductsModel>
            {
                new ProductsModel {
                                Name = "azerty", Products = this.Products
                            },
                new ProductsModel {
                                Name = "azerty", Products = this.Products
                            },
                new ProductsModel {
                                Name = "azerty", Products = this.Products
                            }
            };*/
        }

        public async void OnMoreInfoExecute()
        {
            await _navigationService.NavigateToAsync<OrderNewViewModel>(_selectedItem);
        }
  
    }
}