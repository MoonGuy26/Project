using System;
using System.Threading.Tasks;
using Beanify.Utils.Navigation;
using Xamarin.Forms;

namespace Beanify.ViewModels
{
    public class ErrorViewModel : BaseViewModel
    {
        private string _errorMessage;



        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                if (value != _errorMessage)
                {
                    _errorMessage = value;
                    OnPropertyChanged(nameof(ErrorMessage));
                }
            }
        }
        public Action OnReload { get; set; }

        public ErrorViewModel(INavigationService navigationService) : base(navigationService)
        {
            Commands.Add("Reload", new Command(OnReloadExecute));
        }

        public void OnReloadExecute()
        {
            OnReload();
        }

        public override Task InitializeAsync(object navigationData)
        {
            if (navigationData == null)
            {
                ErrorMessage = "An error has occurred.";
                OnReload = DefaultAction;
            }
            else
            {
                if(navigationData.GetType()==typeof(string)){
                    OnReload = DefaultAction;
                    ErrorMessage = (string)navigationData;
                }
                else if(navigationData.GetType()==typeof(object[])){
                    var args = (object[])navigationData;
                    OnReload = (Action)args[0];
                    ErrorMessage = (string)args[1];
                }
            }
            return base.InitializeAsync(navigationData);
        }

        private void DefaultAction()
        {
            _navigationService.InitializeAsync();   
        }



    }
}
