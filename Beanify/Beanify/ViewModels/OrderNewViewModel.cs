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
    public class OrderNewViewModel : BaseViewModel
    {
        private IAccountService _accountService;

        private ObservableCollection<string> _observable_picker = new ObservableCollection<string>();

        public ObservableCollection<string> ObservablePicker
        {
            get { return _observable_picker;  }
            set {
                if (_observable_picker != value)
                {
                    _observable_picker = value;
                    OnPropertyChanged(nameof(ObservablePicker));
                }
            }
        }

        private string _selectedItem;

        public string SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                    OnPropertyChanged(nameof(SelectedItem));
                }
            }
        }

        private bool _continue = false;

        public bool Continue
        {
            get { return _continue;  }
            set
            {
                if(_continue != value)
                {
                    _continue = value;
                    OnPropertyChanged(nameof(Continue));
                }
            }
        }

        private int _quantity;

        public int Quantity
        {
            get { return _quantity; }
            set
            {
                if (_quantity != value)
                {
                    _continue = true;
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

        static private int capacity = 100;
        private List<string> picker_list = new List<string>(capacity);

        public OrderNewViewModel(IAccountService accountService) : base()
        {
            _accountService = accountService;
            Commands.Add("Continue", new Command(OnContinueExecute));
        }

        private List<string> ListInitializer(List<string> list)
        {
            for (int i = 1; i <= capacity; i++)
            {

                float price = _productModel.Price * i;
                list.Add(i.ToString() + " item(s) : ( £ " + price.ToString("n2") + " )");
            }
            return list;
        }

        public async void OnContinueExecute() {
            await NavigateOrderReviewView();
        }

        private async Task NavigateOrderReviewView()
        {
            var orderModel = new OrderModel
            {
                ProductName = ProductModel.Name,
                Price = _productModel.Price * (_quantity + 1),
                Quantity = _quantity + 1,
                Date = DateTime.Now,
                IsNew = true,
                Id = "6",
                ClientName = "s.daroukh@live.fr",
            };
            var object_list = new List<object>();
            object_list.Add(_productModel);
            object_list.Add(orderModel);


            await _navigationService.NavigateToInsideDashboardAsync<OrderReviewViewModel>(object_list);
        }


        public override Task InitializeAsync(object navigationData)
        {

            ProductModel = (navigationData as ProductModel);
            picker_list = ListInitializer(picker_list);
            ObservablePicker = new ObservableCollection<string>(picker_list);

            return Task.FromResult(true);
        }



    }
}
