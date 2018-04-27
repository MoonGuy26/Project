using Beanify.Services;
using Beanify.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Beanify.ViewModels
{
    public class OrderNewViewModel : BaseViewModel
    {
        private AccountService _accountService;



        public OrderNewViewModel(IAccountService accountService) : base()
        {
            _accountService = new AccountService();

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
