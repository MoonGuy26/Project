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
    public abstract class BaseViewModel:ObservableProperty
    {
       

        public Dictionary<string, ICommand> Commands { get; protected set; }

        protected readonly INavigationService _navigationService;


        public BaseViewModel()
        {
            _navigationService = NavigationService.Instance;
            Commands = new Dictionary<string, ICommand>();
        }

       
        public virtual Task InitializeAsync(object navigationData)
        {
            return Task.FromResult(false);
        }


    }
}
