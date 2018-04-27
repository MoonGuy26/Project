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

        static private int capacity = 100;
        private List<int> picker_list = new List<int>(capacity);


        private List<int> ListInitializer(List<int> list)
        {
            for (int i = 1; i <= capacity; i++)
            {
                list.Add(i);
            }
            return list;
        }

        public OrderNewViewModel(IAccountService accountService) : base()
        {
            _accountService = accountService;

            picker_list = ListInitializer(picker_list);
            _observable_picker = new ObservableCollection<int>(picker_list);

            Commands.Add("Continue", new Command(OnContinueExecute));
        }

        public async void OnContinueExecute() {
            await NavigateOrderReviewView();
        }

        private async Task NavigateOrderReviewView()
        {
            await _navigationService.NavigateToAsync<OrderReviewViewModel>();
        }



    }
}
