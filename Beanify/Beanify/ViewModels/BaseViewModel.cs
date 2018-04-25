using Beanify.Utils.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Beanify.ViewModels
{
    public class BaseViewModel:ObservableProperty
    {
        protected readonly INavigationService _navigationService;

        public Dictionary<string, ICommand> Commands { get; protected set; }

        public BaseViewModel()
        {
            InitializeViewModel();
            var viewModelLocator = new ViewModelLocator();
            _navigationService = viewModelLocator.NavigationService;
        }

        protected virtual void InitializeViewModel()
        {
            Commands = new Dictionary<string, ICommand>();
        }

        public virtual Task InitializeAsync(object navigationData)
        {
            return Task.FromResult(false);
        }


    }
}
