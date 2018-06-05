using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Beanify.Serialization;
using Beanify.Services;
using Beanify.ViewModels;
using Beanify.Views;
using Xamarin.Forms;

namespace Beanify.Utils.Navigation
{
    public class NavigationService : INavigationService
    {


        
        public BaseViewModel PreviousPageViewModel
        {
            get
            {
                var mainPage = Application.Current.MainPage as CustomNavigationView;
                var viewModel = mainPage.Navigation.NavigationStack[mainPage.Navigation.NavigationStack.Count - 2].BindingContext;
                return viewModel as BaseViewModel;
            }
        }

        


        public async Task InitializeAsync()
        {
            if (string.IsNullOrEmpty(LocalStorageSettings.AccessToken))
            {
                await NavigateToAsync<HomeCarouselViewModel>();
            }

            else
            {
                AccountService accountService = new AccountService();
                try
                {
                    var isAuthenticated = await accountService.IsAuthenticated(LocalStorageSettings.AccessToken);
                    if (isAuthenticated)
                        ((App)Application.Current).MainPage = new DashboardNavigationView();
                    else
                    {
                        LocalStorageSettings.AccessToken = null;
                        ((App)Application.Current).MainPage = new Views.LoginView();
                    }
                    

                }
                catch(Exception e)
                {
                    /*if(Device.RuntimePlatform==Device.Android)
                        await InternalSetApplicationPageAsync(typeof(DashboardViewModel), e);
                    else
                    { */
                        await InternalSetApplicationPageAsync(typeof(ErrorViewModel), e.Message);
                    //}
                        
                }

            }
            await Task.FromResult(false);
        }

        public Task NavigateToAsync<TViewModel>() where TViewModel : BaseViewModel
        {
            return InternalNavigateToAsync(typeof(TViewModel), null);
        }

        public Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : BaseViewModel
        {
            return InternalNavigateToAsync(typeof(TViewModel), parameter);
        }

        public Task NavigateToDashboardAsync<TViewModel>() where TViewModel : BaseViewModel
        {
            return InternalNavigateToDashboardAsync(typeof(TViewModel), null);
        }

        public Task NavigateToDashboardAsync<TViewModel>(object parameter) where TViewModel : BaseViewModel
        {
            return InternalNavigateToDashboardAsync(typeof(TViewModel), parameter);
        }

        public Task NavigateToInsideDashboardAsync<TViewModel>() where TViewModel : BaseViewModel
        {
            return InternalNavigateToInsideDashboardAsync(typeof(TViewModel), null);
        }

        public Task NavigateToInsideDashboardAsync<TViewModel>(object parameter) where TViewModel : BaseViewModel
        {
            return InternalNavigateToInsideDashboardAsync(typeof(TViewModel), parameter);
        }

        

        public Task SetRootAsync<TViewModel>() where TViewModel:BaseViewModel
        {
            return InternalSetRootPageAsync(typeof(TViewModel), null);
        }

        public Task SetRootAsync<TViewModel>(object parameter) where TViewModel : BaseViewModel
        {
            return InternalSetRootPageAsync(typeof(TViewModel), parameter);
        }

        public Task SetRootFromPageAsync<TPage>() where TPage : Page
        {
            return InternalNavigateToFromPageAsync(typeof(TPage), null);
        }


        public Task RemoveLastFromBackStackAsync()
        {
            var mainPage = Application.Current.MainPage as CustomNavigationView;

            if (mainPage != null)
            {
                mainPage.Navigation.RemovePage(
                    mainPage.Navigation.NavigationStack[mainPage.Navigation.NavigationStack.Count - 2]);
            }

            return Task.FromResult(true);
        }

        public Task RemoveBackStackAsync()
        {
            var mainPage = Application.Current.MainPage as CustomNavigationView;

            if (mainPage != null)
            {
                for (int i = 0; i < mainPage.Navigation.NavigationStack.Count - 1; i++)
                {
                    var page = mainPage.Navigation.NavigationStack[i];
                    mainPage.Navigation.RemovePage(page);
                }
            }

            return Task.FromResult(true);
        }

        public async Task NavigateBackAsync()
        {
            var navigationPage = Application.Current.MainPage as CustomNavigationView;
            await navigationPage.PopAsync();

        }

        private async Task InternalNavigateToFromPageAsync(Type pageType, object parameter)
        {
            Page page = Activator.CreateInstance(pageType) as Page;
            var navigationPage = Application.Current.MainPage as CustomNavigationView;
            if (navigationPage != null)
            {
                if (NotAlreadyOpened(page, navigationPage))
                {
                    Application.Current.MainPage = new CustomNavigationView(page);
                }
            }
            else
                Application.Current.MainPage = new CustomNavigationView(page);
            await (page.BindingContext as BaseViewModel).InitializeAsync(parameter);
        } 

        private async Task InternalNavigateToAsync(Type viewModelType, object parameter)
        {
            Page page = CreatePage(viewModelType, parameter);
            Type viewType = GetPageTypeForViewModel(viewModelType);



            var navigationPage = Application.Current.MainPage as CustomNavigationView;
            if (navigationPage != null)
            {
                if (NotAlreadyOpened(page,navigationPage))
                {
                     await navigationPage.PushAsync(page);
                }

            }
            else
            {
                Application.Current.MainPage = new CustomNavigationView(page);
            }

            await (page.BindingContext as BaseViewModel).InitializeAsync(parameter);

        }



        private async Task InternalSetRootPageAsync(Type viewModelType, object parameter)
        {
            Page page = CreatePage(viewModelType, parameter);
            Type viewType = GetPageTypeForViewModel(viewModelType);
            var navigationPage = Application.Current.MainPage as CustomNavigationView;
            if (navigationPage != null)
            {
                if (NotAlreadyOpened(page, navigationPage))
                {
                    Application.Current.MainPage = new CustomNavigationView(page);
                }
            }
            else
                Application.Current.MainPage = new CustomNavigationView(page);
            
            await (page.BindingContext as BaseViewModel).InitializeAsync(parameter);
        }

        private async Task InternalNavigateToDashboardAsync(Type viewModelType, object parameter)
        {
            Page page = CreatePage(viewModelType, parameter);
            Type viewType = GetPageTypeForViewModel(viewModelType);


            var masterDetailView = Application.Current.MainPage as DashboardNavigationView;
            var navigationPage = masterDetailView.Detail as CustomNavigationView;
            if (navigationPage != null)
            {
                
                masterDetailView.IsPresented = false;
                
                ( Application.Current.MainPage as DashboardNavigationView ).Detail= new CustomNavigationView(page);
            }
            else
            {
                Application.Current.MainPage = new DashboardNavigationView();
            }

            await (page.BindingContext as BaseViewModel).InitializeAsync(parameter);

        }

        private async Task InternalNavigateToInsideDashboardAsync(Type viewModelType, object parameter)
        {
            Page page = CreatePage(viewModelType, parameter);
            Type viewType = GetPageTypeForViewModel(viewModelType);


            var masterDetailView = Application.Current.MainPage as DashboardNavigationView;
            var navigationPage = masterDetailView.Detail as CustomNavigationView;
            if (navigationPage != null)
            {
                if (NotAlreadyOpened(page, navigationPage))
                {
                    await navigationPage.PushAsync(page);
                    masterDetailView.IsPresented = false;
                }
                    



            }
            else
            {
                Application.Current.MainPage = new DashboardNavigationView();
            }

            await (page.BindingContext as BaseViewModel).InitializeAsync(parameter);

        }

        private async Task InternalSetApplicationPageAsync(Type viewModelType, object parameter)
        {
            Page page = CreatePage(viewModelType, parameter);
            Application.Current.MainPage = page;
            await (page.BindingContext as BaseViewModel).InitializeAsync(parameter);
        }

        private Page CreatePage(Type viewModelType, object parameter)
        {
            Type pageType = GetPageTypeForViewModel(viewModelType);
            if (pageType == null)
            {
                throw new Exception($"Cannot locate page type for {viewModelType}");
            }

            Page page = Activator.CreateInstance(pageType) as Page;
            return page;
        }

        private Type GetPageTypeForViewModel(Type viewModelType)
        {
            var viewName = viewModelType.FullName.Replace("Model", string.Empty);
            var viewModelAssemblyName = viewModelType.GetTypeInfo().Assembly.FullName;
            var viewAssemblyName = string.Format(CultureInfo.InvariantCulture, "{0}, {1}", viewName, viewModelAssemblyName);
            var viewType = Type.GetType(viewAssemblyName);
            return viewType;
        }

        private bool NotAlreadyOpened(Page currentPage,CustomNavigationView navigationPage)
        {
            return (navigationPage.Navigation.NavigationStack.Count == 0 ||
                  navigationPage.Navigation.NavigationStack.Last().GetType() != currentPage.GetType());
           
        }

        
    }
}
