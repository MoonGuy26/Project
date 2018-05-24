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
        public OrderPopUpViewModel OrderPopUpViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<OrderPopUpViewModel>();
            }
        }

        public LogoutPopUpViewModel LogoutPopUpViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LogoutPopUpViewModel>();
            }
        }

        public PreviousOrdersViewModel PreviousOrdersViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<PreviousOrdersViewModel>();
            }
        }

        public ProductsViewModel ProductsViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ProductsViewModel>();
            }
        }


        public ButtonHomePageViewModel ButtonHomePageViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ButtonHomePageViewModel>();
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

        public OrderNewViewModel OrderNewViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<OrderNewViewModel>();
            }
        }

        public OrderReviewViewModel OrderReviewViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<OrderReviewViewModel>();
            }
        }

        public HomeCarouselViewModel HomeCarouselViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<HomeCarouselViewModel>();
            }
        }

        public HomePageViewModel HomePageViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<HomePageViewModel>();
            }
        }

        public SecondPageViewModel SecondPageViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SecondPageViewModel>();
            }
        }

        public ErrorPopupViewModel ErrorPopupViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ErrorPopupViewModel>();
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
