using AgendApp.Services;
using Beanify.Models;
using Beanify.Utils.Validations;

using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Beanify.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        #region fields
        private ValidatableObject<string> _email;
        private ValidatableObject<string> _password;
        #endregion


        

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
            //await registerUserService.AddUser(Email.Value, Password.Value, Password.Value);
            //await registerUserService.AddUser("test@gmail.com", "testtest1212", "testtest1212");
            
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
