using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Beanify.ViewModels
{
    public class ErrorPopupViewModel : BaseViewModel
    {
        private string _errorMessage;

        public string ErrorMessage { get => _errorMessage;
            set
            {
                if (value != _errorMessage)
                {
                    _errorMessage = value;
                    OnPropertyChanged(nameof(ErrorMessage));
                }
            }
        }

        public ErrorPopupViewModel() : base()
        {
            Commands.Add("ClosePopup", new Command(OnClosePopupExecute));
        }

        public void OnClosePopupExecute()
        {
            PopupNavigation.Instance.PopAsync();
        }

        public override Task InitializeAsync(object navigationData)
        {
            if (navigationData == null)
            {
                ErrorMessage = "An error has occurred.";
            }
            else
            {
                ErrorMessage = (string)navigationData;
            }
            return base.InitializeAsync(navigationData);
        }




    }
}
