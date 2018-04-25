using Beanify.Services;
using Beanify.Utils.Navigation;
using Beanify.ViewModels.CarouselViewModels;
using CommonServiceLocator;
using System;
using System.Collections.Generic;
using System.Text;
using Unity;
using Unity.ServiceLocation;

namespace Beanify.ViewModels
{
    public class ViewModelLocator
    {
        public LastPageViewModel LastPageViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LastPageViewModel>();
            }
        }

        public DashboardViewModel DashboardViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<DashboardViewModel>();
            }
        }

        public ForgottenPasswordViewModel ForgottenPasswordViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ForgottenPasswordViewModel>();
            }
        }

        public LoginViewModel LoginViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LoginViewModel>();
            }
        }

        public NavigationService NavigationService
        {
            get
            {
                return ServiceLocator.Current.GetInstance<NavigationService>();
            }
        }


        

        
    }
}
