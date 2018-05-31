﻿using Beanify.Utils.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Beanify.ViewModels.CarouselViewModels
{
    public class ButtonHomePageViewModel : HomePageViewModel
    {
        #region fields

        #endregion

        #region properties

        #endregion

        public ButtonHomePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Commands.Add("Login", new Command(OnLoginExecute));
        }

        #region commandMethods

        #region execute
        private async void OnLoginExecute()
        {
            await NavigateLoginView();
        }
        #endregion

        #region canExecute
        
        #endregion

        #endregion

        #region navigateMethods
        private async Task NavigateLoginView()
        {
            await _navigationService.NavigateToAsync<LoginViewModel>();
        }
        #endregion

    }
}
