using Beanify.Utils.Validations;
using Beanify.Views.Validators;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Beanify.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {

        private ValidatableObject<string> _email;
        private ValidatableObject<string> _password;

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


        

        public LoginViewModel(INavigation navigation) : base(navigation)
        {
            Commands.Add("Login", new Command(OnLoginExecute, CanLoginExecute));
            _email = new ValidatableObject<string>();
            AddValidations();
        }

        private bool CanLoginExecute()
        {
            return true;
        }

        private void OnLoginExecute()
        {

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
