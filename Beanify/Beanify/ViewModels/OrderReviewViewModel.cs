using Beanify.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beanify.ViewModels
{
    public class OrderReviewViewModel : BaseViewModel
    {
        private AccountService _accountService;

        public OrderReviewViewModel(IAccountService accountService) : base() {
            _accountService = new AccountService();
        }
    }
}
