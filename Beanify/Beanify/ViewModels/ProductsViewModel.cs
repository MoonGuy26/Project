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


        public ProductsViewModel() : base()
        {
            //ProductService productService = new ProductService();

            Products = new ObservableCollection<ProductModel>
            {
                new ProductModel {
                    Name = "Qwerty",Description = "azerty", Price = 12 , ImagePath = "@drawable/Lightstart1.jpg"
                },
                new ProductModel {
                    Name = "Jean",Description = "azerty", Price = 12 , ImagePath = "@drawable/Lightstart2.jpg"
                },
                new ProductModel {
                    Name = "Pierre",Description = "azerty", Price = 12 , ImagePath = "@drawable/Lightstart3.jpg"
                }

            };
            Commands.Add("LoadingDetails", new Command(OnMoreInfoExecute));


            //Products = new ObservableCollection<ProductModel>(productService.GetProducts().Result);

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
            await _navigationService.NavigateToAsync<OrderNewViewModel>();
        
        }
  
    }
}