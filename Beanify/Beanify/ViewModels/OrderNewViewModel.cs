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

        private ObservableCollection<int> _observable_picker;

        public ObservableCollection<int> ObservablePicker
        {
            get { return _observable_picker;  }
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
        private List<int> picker_list = new List<int>(capacity);

        public OrderNewViewModel(IAccountService accountService) : base()
        {

            _accountService = accountService;

            picker_list = ListInitializer(picker_list);
            _observable_picker = new ObservableCollection<int>(picker_list);

            Commands.Add("Continue", new Command(OnContinueExecute));
        }

        private List<int> ListInitializer(List<int> list)
        {
            for (int i = 1; i <= capacity; i++)
            {
                list.Add(i);
            }
            return list;
        }

        public async void OnContinueExecute() {
            await NavigateOrderReviewView();
        }

        private async Task NavigateOrderReviewView()
        {
            await _navigationService.NavigateToAsync<OrderReviewViewModel>();
        }


        public override Task InitializeAsync(object navigationData)
        {

            ProductModel = (navigationData as ProductModel);
            return Task.FromResult(true);
            //return base.InitializeAsync(navigationData);
        }



    }
}
