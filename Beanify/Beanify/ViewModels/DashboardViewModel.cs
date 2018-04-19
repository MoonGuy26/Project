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

        private string _accessToken;

        private AccountService accountService;

        public DashboardViewModel(INavigation navigation) : base(navigation)
        {
            Commands.Add("Logout",new Command(OnLogoutExecute));
            _accessToken = LocalStorageSettings.AccessToken;
            GetCurrentUserRole();
            
        }

        private void OnLogoutExecute()
        {
            LocalStorageSettings.AccessToken = null;
            ((App)Application.Current).MainPage = new NavigationPage(new Views.CarouselViews.CustomCarouselPage());
        }

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
    }
}
