using Beanify.Serialization;
using Beanify.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Beanify.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        #region fields
        private string _dashboardMessage;
        private string _accessToken;
        private AccountService accountService;
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

        public DashboardViewModel():base()
        {
            Commands.Add("Logout",new Command(OnLogoutExecute));
            _accessToken = LocalStorageSettings.AccessToken;
            GetCurrentUserRole();    
        }

        #region commandMethods
        #region execute
        private void OnLogoutExecute()
        {
            LocalStorageSettings.AccessToken = null;
            ((App)Application.Current).MainPage = new NavigationPage(new Views.CarouselViews.CustomCarouselPage());
        }
        #endregion
        #region canExecute
        #endregion
        #endregion

        #region logicMethods
        private async void GetCurrentUserRole()
        {
            accountService = new AccountService();
            var isAdmin = await accountService.IsAdmin(_accessToken);
            if(isAdmin)
            {
                DashboardMessage = "ADMIN DASHBOARD";
            }
            else
            {
                DashboardMessage = "USER DASHBOARD";
            }
        }
        #endregion
    }
}
