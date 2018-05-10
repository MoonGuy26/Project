using Beanify.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Beanify.Utils.Navigation
{
    public interface INavigationService
    {
        BaseViewModel PreviousPageViewModel { get; }
        Task InitializeAsync();
        Task SetRootAsync<TViewModel>() where TViewModel : BaseViewModel;
        Task SetRootAsync<TViewModel>(object parameter) where TViewModel : BaseViewModel;
        Task SetRootFromPageAsync<TPage>() where TPage : Page;
        Task NavigateToAsync<TViewModel>() where TViewModel : BaseViewModel;
        Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : BaseViewModel;
        Task NavigateToDashboardAsync<TViewModel>() where TViewModel : BaseViewModel;
        Task NavigateToDashboardAsync<TViewModel>(object parameter) where TViewModel : BaseViewModel;
        Task NavigateBackAsync();
        Task RemoveLastFromBackStackAsync();
        Task RemoveBackStackAsync();
    }
}
