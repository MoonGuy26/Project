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
        private ProductModel _selectedItem;

        public ObservableCollection<ProductsModel> Categ
        {
            get; set;
        }

        public ObservableCollection<ProductModel> Products
        {
            get; set;
        }
        public ProductModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (_selectedItem != value && value != null)
                {
                    if (_selectedItem != null)
                    {
                        //Products[Products.IndexOf(_selectedItem)].IsSelected = false;
                    }
                    _selectedItem = value;
                    //Products[Products.IndexOf(_selectedItem)].IsSelected = true;
                    OnPropertyChanged(nameof(SelectedItem));
                }
            }
        }

        public ProductsViewModel() : base()
        {
            
            ProductService productService = new ProductService();

            Products = new ObservableCollection<ProductModel>
            {
                new ProductModel {
                    Name = "Qwerty",Description = "DDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD", Price = 12 , ImagePath = "@drawable/Lightstart1.jpg"
                },
                new ProductModel {
                    Name = "Jean",Description = "DDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD", Price = 12 , ImagePath = "@drawable/Lightstart2.jpg"
                },
                new ProductModel {
                    Name = "Pierre",Description = "DDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD", Price = 12 , ImagePath = "@drawable/Lightstart3.jpg"
                }

            };
            Commands.Add("LoadingDetails", new Command(OnMoreInfoExecute));


           // Products = new ObservableCollection<ProductModel>(productService.GetProducts().Result);

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

        public ProductModel FindSelectedItem(ObservableCollection<ProductModel> productModels) {
            foreach (ProductModel items in productModels)
            {
                //if (items.IsSelected == true) { return items;  }
            }
            return null;

        }

        public async void OnMoreInfoExecute()
        {
            //await _navigationService.NavigateToAsync<OrderNewViewModel>(FindSelectedItem(Products));
            await _navigationService.NavigateToAsync<OrderNewViewModel>(_selectedItem);

        }
  
    }
}