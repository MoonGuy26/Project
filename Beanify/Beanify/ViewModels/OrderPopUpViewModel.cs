using Beanify.Serialization;
using Beanify.Services;
using Beanify.Utils.Navigation;
using Beanify.Views;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Beanify.ViewModels
{
    public class OrderPopUpViewModel : BaseViewModel
    {
        private IAccountService _accountService;

        public OrderPopUpViewModel(IAccountService accountService,INavigationService navigationService) :base(navigationService)
        {
            _accountService = accountService;

            Commands.Add("Yes", new Command(OnYesExecute));
            Commands.Add("No", new Command(OnNoExecute));
        }

        public void OnYesExecute()
        {
            PopupNavigation.Instance.PopAsync();
            MessagingCenter.Send<OrderPopUpViewModel>(this, "Yes");
        }

        public void OnNoExecute()
        {
            PopupNavigation.Instance.PopAsync();
        }

    }
}
