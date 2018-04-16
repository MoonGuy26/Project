using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Beanify.ViewModels
{
    public abstract class BaseViewModel:ObservableProperty
    {
        protected INavigation _navigation;

        public Dictionary<string, ICommand> Commands { get; protected set; }

        public BaseViewModel(INavigation navigation){
            _navigation = navigation;
            Commands = new Dictionary<string, ICommand>();
        }

        
    }
}
