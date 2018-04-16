using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Beanify.ViewModels.CarouselViewModels
{
    public class Page3viewModel : BaseViewModel
    {

        public Command LoginCommand { get; }

        public Page3viewModel(INavigation navigation) : base(navigation)
        {
            LoginCommand = new Command(OnLoginExecute, CanExecuteLogin);
        }

        private bool CanExecuteLogin()
        {
            return true;
        }

        private void OnLoginExecute()
        {
            //((App)Application.Current).MainPage= new NavigationPage(new Views.LoginView());
            _navigation.PushModalAsync(new Views.LoginView());
        }
    }
}
