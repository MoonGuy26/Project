using Beanify.Services;
using Beanify.Models;
using Beanify.Utils.Validations;

using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Beanify.Serialization;

namespace Beanify.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        #region fields
        private ValidatableObject<string> _email;
        private ValidatableObject<string> _password;
        #endregion

        private AccountService accountService;
        

        #region properties
        public ValidatableObject<string> Email
        {
            get { return _email; }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged(nameof(Email));
                    ValidateUserName();
                }
            }
        }
        public ValidatableObject<string> Password
        {
            get { return _password; }
            set
            {
                if(_password != value)
                {
                    _password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }
        #endregion

        public LoginViewModel(INavigation navigation) : base(navigation)
        {
            AccountService addDefault = new AccountService("api/Account/Register/");
            
            accountService = new AccountService("Token");
            Commands.Add("Login", new Command(OnLoginExecute, CanLoginExecute));
            _email = new ValidatableObject<string>();
            _password = new ValidatableObject<string>();
            AddValidations();
        }

        private bool CanLoginExecute()
        {
            return true;
        }

        private async void OnLoginExecute()
        {
            LocalStorageSettings.AccessToken = await accountService.LoginUser(Email.Value, Password.Value);  
            if (!string.IsNullOrEmpty(LocalStorageSettings.AccessToken)){
                ((App)Application.Current).MainPage = new NavigationPage(new Views.DashboardView());
            }
        }

        private void AddValidations()
        {
            _email.Validations.Add(new IsNotNullOrEmptyRule<string>
            {
                ValidationMessage = "An email adress is required."
            });
        }

	
        private bool ValidateUserName()
        {
            return _email.Validate();
        }
    }
}
