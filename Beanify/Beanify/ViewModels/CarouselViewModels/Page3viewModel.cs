using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Beanify.ViewModels.CarouselViewModels
{
    public class Page3viewModel : BaseViewModel
    {

        private Command loginCommand; 

        public Page3viewModel(INavigation navigation) : base(navigation)
        {
            loginCommand = new Command(OnLoginExecute, CanExecuteLogin);
        }

        private bool CanExecuteLogin()
        {
            return true;
        }

        private void OnLoginExecute()
        {
            
        }
    }
}
