using Beanify.Services;
using Beanify.Utils.Validations;
using System;
using Xamarin.Forms;
using Beanify.Serialization;
using System.Threading.Tasks;
using System.Threading;
using Beanify.Utils.Parallels;
using System.Diagnostics;
using Beanify.Utils.Orientation;
using Beanify.Utils.Navigation;

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
       
        private bool _isFocusedPassword;

        


        private IAccountService _accountService;
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

        public bool IsFocusedPassword
        {
            get {
                return _isFocusedPassword;
                
            }
            set {
                _isFocusedPassword = value;
                OnPropertyChanged(nameof(IsFocusedPassword));
            }
        }

        #endregion



        public LoginViewModel(IAccountService accountService,INavigationService navigationService) :base(navigationService)
        {
            _accountService = accountService;
        }

        

        override protected void InitializeViewModel()
        {
            base.InitializeViewModel();
            AddValidations();


            Commands.Add("OfflineLogin", new Command(OnNoLoginExecute));
            Commands.Add("Login", new Command(OnLoginExecute, CanLoginExecute));
            Commands.Add("ResetPassword", new Command(OnForgottenExecute));
            Commands.Add("LostFocusEmail", new Command(OnLostFocusEmailExecute));
            Commands.Add("CompletedEmail", new Command(OnCompletedEmailExecute));
            //Commands.Add("SizeChanged", new Command(OnSizeChangedExecute));
            Commands.Add("PlayingAnimation", new Command(OnPlayingAnimationExecute));
            Commands.Add("FinishedAnimation", new Command(OnFinishedAnimationExecute));


            Email.IsValid = true;
            Password.IsValid = true;
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

        #region commandMethods

        #region execute
        private async void OnNoLoginExecute()
        {
            await _navigationService.NavigateToAsync<DashboardViewModel>();
        }

        private void OnLostFocusEmailExecute()
        {
            //ValidateUserName();
            IsFocusedPassword = true;
        }

        private void OnCompletedEmailExecute()
        {
            IsFocusedPassword = true;
        }

        private async void OnLoginExecute()
        {
            await NavigateDashboardView();
        }

        private async void OnForgottenExecute()
        {
            await NavigateForgottenView();
        }

       /* private void OnSizeChangedExecute()
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
        }*/

        private void OnPlayingAnimationExecute()
        {

        }

        private void OnFinishedAnimationExecute()
        {

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
                    LocalStorageSettings.AccessToken = await _accountService.LoginUser(Email.Value, Password.Value);
                    if (!string.IsNullOrEmpty(LocalStorageSettings.AccessToken))
                    {
                        cts.Cancel();
                        IsVisibleImage = false;
                        await _navigationService.InitializeAsync();
                        //((App)Application.Current).MainPage = new NavigationPage(new Views.DashboardView());
                    }

                }
                else
                {
                    throw new Exception("Fields are not correctly filled");
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
            var email = "";
            if (ValidateUserName())
            {
                email = Email.Value;
            }
            await _navigationService.NavigateToAsync<ForgottenPasswordViewModel>(email);
        }
        #endregion

        #region validationMethods
        private void AddValidations()
        {
            _email = new ValueChangedValidatableObject<string>();
            _password = new ValueChangedValidatableObject<string>();

            _email.Validations.Add(new IsNotNullOrEmptyRule<string>
            {
                ValidationMessage = "An email address is required"
            });
            _email.Validations.Add(new IsValidEmailRule<string>
            {
                ValidationMessage = "Please enter a valid email address"
            });

            _password.Validations.Add(new IsNotNullOrEmptyRule<string>
            {
                ValidationMessage = "A password is required"
            });

            /*
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
            });*/
            
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
