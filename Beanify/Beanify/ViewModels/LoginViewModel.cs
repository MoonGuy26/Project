using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Beanify.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {

        public Command LoginCommand { get; }

        public LoginViewModel(INavigation navigation) : base(navigation)
        {

            LoginCommand = new Command(OnLoginExecute, CanLoginExecute);
        }

        private bool CanLoginExecute()
        {
            return true;
        }

        private void OnLoginExecute()
        {
            
        }
    }
}
