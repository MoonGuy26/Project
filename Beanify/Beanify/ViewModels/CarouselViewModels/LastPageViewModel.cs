using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Beanify.ViewModels.CarouselViewModels
{
    public class LastPageViewModel : BaseViewModel
    {

        public Command LoginCommand { get; }

        public LastPageViewModel():base()
        {
            LoginCommand = new Command(OnLoginExecute, CanExecuteLogin);
        }

        private bool CanExecuteLogin()
        {
            return true;
        }

        private async void  OnLoginExecute()
        {
            await NavigateLoginView();
            //((App)Application.Current).MainPage= new NavigationPage(new Views.LoginView());
            //if (_navigation.NavigationStack.Count == 0 ||
            //    _navigation.NavigationStack.Last().GetType() != typeof(Views.LoginView))
            //{
            //    await _navigation.PushAsync(new Views.LoginView(), true);
            //}
            
        }

        private async Task NavigateLoginView()
        {
            await _navigationService.NavigateToAsync<LoginViewModel>();
        }
    }
}
