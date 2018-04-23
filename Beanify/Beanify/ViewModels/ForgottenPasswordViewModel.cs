using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Beanify.ViewModels
{
    public class ForgottenPasswordViewModel : BaseViewModel
    {

        public ForgottenPasswordViewModel():base()
        {
            Commands.Add("ForgottenComplete", new Command(OnForgottenCompleteExecute));
        }

        private void OnForgottenCompleteExecute()
        {
          
            
        }

        private bool CanForgottenComplete() {
            return true;
        }
    }
}
