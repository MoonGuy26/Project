using Beanify.Serialization;
using Beanify.Services;
using Beanify.Utils.Navigation;

namespace Beanify.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {

        public DashboardViewModel(INavigationService navigationService) : base(navigationService){}

    }
}