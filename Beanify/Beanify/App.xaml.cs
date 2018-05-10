using Beanify.Serialization;
using Beanify.Services;
using Beanify.Utils.Navigation;
using Beanify.ViewModels;
using Beanify.ViewModels.CarouselViewModels;
using CommonServiceLocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.ServiceLocation;
using Xamarin.Forms;

namespace Beanify
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            


            InitNavigation();
        }

        private void SetMainPage()
        {
            if (!string.IsNullOrEmpty(LocalStorageSettings.AccessToken))
            {
                MainPage = new NavigationPage(new Views.DashboardView());
            }
            else
            { 
                MainPage = new NavigationPage(new Views.HomeCarouselView());
            }

        }

        private Task InitNavigation()
        {
            
            UnityContainer unityContainer = new UnityContainer();
            unityContainer.RegisterType<IBaseService, BaseService>();
            unityContainer.RegisterType<IAccountService, AccountService>();
            unityContainer.RegisterType<IOrderService, OrderService>();
            unityContainer.RegisterSingleton<INavigationService, NavigationService>();
            unityContainer.RegisterType<IProductService, ProductService>();
            unityContainer.RegisterType<LastPageViewModel>();
            unityContainer.RegisterType<LoginViewModel>();
            unityContainer.RegisterType<HomeCarouselViewModel>();
            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(unityContainer));
            var viewModelLocator = new ViewModelLocator();
            var navigationService = viewModelLocator.NavigationService;
            return navigationService.InitializeAsync();
        }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
