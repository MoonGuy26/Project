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
    public class LogoutPopUpViewModel : BaseViewModel
    {
        private IAccountService _accountService;

        public LogoutPopUpViewModel(IAccountService accountService,INavigationService navigationService) :base(navigationService) 
        {
            _accountService = accountService;

            Commands.Add("Yes", new Command(OnYesExecute));
            Commands.Add("No", new Command(OnNoExecute));
        }

        public void OnYesExecute()
        {
            LocalStorageSettings.AccessToken = null;
            LocalStorageSettings.Email = null;
            LocalStorageSettings.Password = null;
            ((App)Application.Current).MainPage = new Views.LoginView();

            PopupNavigation.Instance.PopAsync();


        }

        public void OnNoExecute()
        {
            PopupNavigation.Instance.PopAsync();
        }
    
    }
}
