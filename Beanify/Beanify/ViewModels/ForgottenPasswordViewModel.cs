using Beanify.Services;
using Beanify.Utils.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Beanify.ViewModels
{
    public class ForgottenPasswordViewModel : BaseViewModel
    {
        private IAccountService _accountService;

        private ValidatableObject<string> _email;
        private string _textConfirmation;
        private bool _isVisibleLoading;

        public bool IsVisibleLoading
        {
            get { return _isVisibleLoading; }
            set {
                _isVisibleLoading = value;
                OnPropertyChanged(nameof(IsVisibleLoading));
            }
        }


        public ValidatableObject<string> Email
        {
            get { return _email; }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }

        public string TextConfirmation
        {
            get { return _textConfirmation; }
            set
            {
                if (_textConfirmation != value)
                {
                    _textConfirmation = value;
                    OnPropertyChanged(nameof(TextConfirmation));
                }
            }
        }

        public ForgottenPasswordViewModel(IAccountService accountService) : base()
        {
            _accountService = accountService;
            Commands.Add("ForgottenComplete", new Command(OnForgottenCompleteExecute));
            Commands.Add("LoginNavigation", new Command(OnLoginNavigationExecute));
            TextConfirmation = "Please enter your account email adress and press Reset Password to get your reset link";

            AddValidations();
        }

        public override Task InitializeAsync(object navigationData)
        {
            if (navigationData != null)
            {
                var email = (string)navigationData;
                Email.Value = email;
            }

            return base.InitializeAsync(navigationData);
        }

        private void AddValidations()
        {
            _email = new ValidatableObject<string>();
           

            _email.Validations.Add(new IsNotNullOrEmptyRule<string>
            {
                ValidationMessage = "An email adress is required"
            });
            _email.Validations.Add(new IsValidEmailRule<string>
            {
                ValidationMessage = "Please enter a valid email address"
            });
        }

        private bool ValidateEmail()
        {
            return Email.Validate();
        }


        private async void OnForgottenCompleteExecute()
        { 
            if (ValidateEmail())
            {
                IsVisibleLoading = true;
                //TextConfirmation = "Sending";
                await _accountService.ForgottenPassword(Email.Value);
                IsVisibleLoading = false;
                TextConfirmation = "An email will be send to your email inbox. This process can take a few minutes.";
            }
            
        }
        private async void OnLoginNavigationExecute()
        {
            await _navigationService.NavigateBackAsync();
        }

        
    }
}