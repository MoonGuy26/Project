using Beanify.Services;
using Beanify.Utils.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Beanify.ViewModels
{
    public class ForgottenPasswordViewModel : BaseViewModel
    {
        private AccountService accountService;

        private ValidatableObject<string> _email;

        public ValidatableObject<string> Email
        {
            get { return _email; }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged(nameof(Email));
                    _email.Validate();
                }
            }
        }

        private string _textConfirmation;

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

        public ForgottenPasswordViewModel(INavigation navigation) : base()
        {
            accountService = new AccountService("api/Account/ForgotPassword/");
            //accountService = new AccountService("Token");
            Commands.Add("ForgottenComplete", new Command(OnForgottenCompleteExecute));
            _email = new ValidatableObject<string>();
        }

        private async void OnForgottenCompleteExecute()
        {

            await accountService.ForgottenPassword(Email.Value);
            TextConfirmation = "A email has been sent to your email inbox, please go check it !";

            //_navigation.PopModalAsync();
        }

        private bool CanForgottenComplete()
        {
            return true;
        }
    }
}
