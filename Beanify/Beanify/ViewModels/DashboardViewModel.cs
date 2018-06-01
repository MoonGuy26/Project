using Beanify.Serialization;
using Beanify.Services;
using Beanify.Utils.Navigation;
using Beanify.Views;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Beanify.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        #region fields
        private string _dashboardMessage;
        private string _accessToken;

        #endregion

        #region properties
        public string DashboardMessage
        {
            get { return _dashboardMessage; }
            set {
                if (_dashboardMessage != value)
                {
                   _dashboardMessage = value;
                    OnPropertyChanged(nameof(DashboardMessage));
                }
            }
        }

        
        #endregion

        public DashboardViewModel(INavigationService navigationService) : base(navigationService)
        {
            
        }

        #region commandMethods
        #region execute



        #endregion
        #region canExecute
        #endregion
        #endregion

        public override Task InitializeAsync(object navigationData)
        {
            if (navigationData != null)
            {
                var exception = navigationData as Exception;
                PopupPage popup = new CallBackPopupView();
                PopupNavigation.Instance.PushAsync(popup);
                var errorMessage =exception.Message;
                
                (popup.BindingContext as BaseViewModel).InitializeAsync(errorMessage);
            }
            return base.InitializeAsync(navigationData);
        }

        #region logicMethods


        #endregion
    }
}