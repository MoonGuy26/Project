using Beanify.Services;
using Beanify.Models;
using Beanify.Utils.Validations;
using Beanify.Utils.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Beanify.Serialization;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

using Beanify.Utils.Parallels;
using System.Diagnostics;
using Beanify.Utils.Orientation;

namespace Beanify.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        #region fields
        private ValidatableObject<string> _email;
        private ValueChangedValidatableObject<string> _password;
        private string _errorLoginMessage;
        private int _imageAngle = 0 ;
        private bool _isVisibleImage = false;
        private StackOrientation _screenOrientation;


        private AccountService accountService;
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
                }
            }
        }
        public ValueChangedValidatableObject<string> Password
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
        public string ErrorLoginMessage
        {
            get { return _errorLoginMessage; }
            set
            {
                if (_errorLoginMessage != value)
                {
                    _errorLoginMessage = value;
                    OnPropertyChanged(nameof(ErrorLoginMessage));
                }
            }
        }
        public int ImageAngle
        {
            get { return _imageAngle; }
            set
            {
                if (_imageAngle != value)
                {
                    _imageAngle = value%360;
                    OnPropertyChanged(nameof(ImageAngle));
       
                }
            }
        }
        public bool IsVisibleImage
        {
            get { return _isVisibleImage; }
            set
            {
                if(_isVisibleImage != value)
                {
                    _isVisibleImage = value;
                    OnPropertyChanged(nameof(IsVisibleImage));
                }
            }
        }
        public StackOrientation ScreenOrientation
        {
            get{ return _screenOrientation; }
            set
            {
                if (_screenOrientation != value)
                {
                    _screenOrientation = value;
                    OnPropertyChanged(nameof(ScreenOrientation));
                }
            }
        }

        #endregion

        public LoginViewModel() : base()
        {
            AddValidations();
            AccountService addDefault = new AccountService("api/Account/Register/");
            
            accountService = new AccountService("Token");
            Commands.Add("Login", new Command(OnLoginExecute, CanLoginExecute));
            Commands.Add("ResetPassword", new Command(OnForgottenExecute));
            Commands.Add("LostFocusEmail", new Command(OnLostFocusEmailExecute));
            Commands.Add("SizeChanged", new Command(OnSizeChangedExecute));
            
            
            Email.IsValid = true;
            Password.IsValid = true;
        }

        #region commandMethods

        #region execute
        private void OnLostFocusEmailExecute()
        {
            ValidateUserName();
        }

        private async void OnLoginExecute()
        {
            await NavigateDashboardView();
        }

        private async void OnForgottenExecute()
        {
            await NavigateForgottenView();
        }

        private void OnSizeChangedExecute()
        {
            var orientation = DependencyService.Get<IDeviceOrientation>().GetOrientation();
            switch (orientation)
            {
                case DeviceOrientations.Undefined:
                    
                    break;
                case DeviceOrientations.Landscape:
                    ScreenOrientation = StackOrientation.Horizontal;
                    break;
                case DeviceOrientations.Portrait:
                    ScreenOrientation = StackOrientation.Vertical;
                    break;
            }

            Debug.WriteLine(ScreenOrientation);
        }
        #endregion

        #region canExecute
        private bool CanLoginExecute()
        {
            return true;
        }
        #endregion

        #endregion

        #region navigateMethods
        private async Task NavigateDashboardView()
        {
            ErrorLoginMessage = "";

            CancellationTokenSource cts = new CancellationTokenSource();
            var token = cts.Token;
            IsVisibleImage = true;
            RotateElement(token);
            try
            {
                if (ValidateUserName() & ValidatePassword())
                {
                    LocalStorageSettings.AccessToken = await accountService.LoginUser(Email.Value, Password.Value);
                    if (!string.IsNullOrEmpty(LocalStorageSettings.AccessToken))
                    {
                        cts.Cancel();
                        IsVisibleImage = false;
                        await _navigationService.NavigateToAsync<DashboardViewModel>();
                        //((App)Application.Current).MainPage = new NavigationPage(new Views.DashboardView());
                    }

                }
                else
                {
                    throw new Exception("Fields are not correctly filled.");
                }

            }
            catch(Exception e)
            {
                ErrorLoginMessage = e.Message;
                cts.Cancel();
                IsVisibleImage = false;
            }
        }

        private async Task NavigateForgottenView()
        {
            await _navigationService.NavigateToAsync<ForgottenPasswordViewModel>();
        }
        #endregion

        #region validationMethods
        private void AddValidations()
        {
            _email = new ValidatableObject<string>();
            _password = new ValueChangedValidatableObject<string>();

            _email.Validations.Add(new IsNotNullOrEmptyRule<string>
            {
                ValidationMessage = "An email adress is required."
            });
            _email.Validations.Add(new IsValidEmailRule<string>
            {
                ValidationMessage = "Please enter a valid email address."
            });

            _password.Validations.Add(new IsNotNullOrEmptyRule<string>
            {
                ValidationMessage = "A password is required."
            });
            _password.Validations.Add(new LengthValidationRule<string>("Password must be at least 6 characters.", 6));
            _password.Validations.Add(new ContainLowercaseRule<string>
            {
                ValidationMessage = "Password must contain at least one lowercase character."
            });
            _password.Validations.Add(new ContainUppercaseRule<string>
            {
                ValidationMessage = "Password must contain at least one uppercase character."
            });
            _password.Validations.Add(new ContainDigitRule<string>
            {
                ValidationMessage = "Password must contain at least one digit."
            });
            _password.Validations.Add(new ContainNonLetterOrDigitRule<string>
            {
                ValidationMessage = "Password must contain at least one special character."
            });
            
        }

        private bool ValidateUserName()
        {
            return _email.Validate();
        }

        private bool ValidatePassword()
        {
            return _password.Validate();
        }
        #endregion

        #region UIMethods
        private void RotateElement(CancellationToken cancellation)
        {
            ParallelTask parallelTask = new ParallelTask();
            

            Task t = Task.Factory.StartNew(
                () => {
                    parallelTask.ExecuteParallelLoop(cancellation, "45", value => ImageAngle += Int32.Parse(value));
                },
                cancellation,
                TaskCreationOptions.LongRunning,
                TaskScheduler.Default
            );
            
        }
        
        #endregion
    }
}
