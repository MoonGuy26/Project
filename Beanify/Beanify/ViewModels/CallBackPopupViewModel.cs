using Beanify.Utils.Navigation;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Beanify.ViewModels
{
    public class CallBackPopupViewModel: BaseViewModel
    {
        private string _message;
        private bool _reloadOnClose;
        private string _buttonMessage;

        


        public string Message
        {
            get => _message;
            set
            {
                if (value != _message)
                {
                    _message = value;
                    OnPropertyChanged(nameof(Message));
                }
            }
        }

        public string ButtonMessage
        {
            get { return _buttonMessage; }
            set { _buttonMessage = value;
                OnPropertyChanged(nameof(ButtonMessage));
            }
        }

        public CallBackPopupViewModel(INavigationService navigationService) : base(navigationService)
        {
            ButtonMessage = "OK";
            Commands.Add("ClosePopup", new Command(OnClosePopupExecute));
        }

        public void OnClosePopupExecute()
        {
            if(_reloadOnClose)
                _navigationService.InitializeAsync();
            PopupNavigation.Instance.PopAsync();
        }

        public override Task InitializeAsync(object navigationData)
        {
            if (navigationData == null)
            {
                Message = "An error has occurred.";
            }
            else
            {
                if (navigationData.GetType() == typeof(bool))
                {
                    _reloadOnClose = (bool)navigationData;
                    if (_reloadOnClose)
                    {
                        ButtonMessage = "RELOAD";
                    }
                }
                if (navigationData.GetType() == typeof(string))
                {
                    Message = (string)navigationData;
                }
            }
            return base.InitializeAsync(navigationData);
        }

    
    }
}
