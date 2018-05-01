using Beanify.Services;
using Beanify.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Beanify.ViewModels
{
    public class OrderReviewViewModel : BaseViewModel
    {
        private AccountService _accountService;



        public OrderReviewViewModel(IAccountService accountService) : base()
        {
            _accountService = new AccountService();

            Commands.Add("Order", new Command(OnOrderExecute));
        }

        public async void OnOrderExecute()
        {
            await _accountService.OrderConfirmation();
        }

    }
}
