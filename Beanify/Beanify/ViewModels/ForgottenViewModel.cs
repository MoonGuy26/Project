using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Beanify.ViewModels
{
    public class ForgottenViewModel : BaseViewModel
    {

        public ForgottenViewModel(INavigation navigation) : base(navigation)
        {
            Commands.Add("ForgottenComplete", new Command(OnForgottenCompleteExecute));
        }

        private void OnForgottenCompleteExecute()
        {
            Console.WriteLine("mlkjhgf");
            _navigation.PopModalAsync();
        }

        private bool CanForgottenComplete() {
            return true;
        }
    }
}
