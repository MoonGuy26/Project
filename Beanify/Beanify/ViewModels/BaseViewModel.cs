using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Beanify.ViewModels
{
    public abstract class BaseViewModel
    {
        protected INavigation _navigation;

        public BaseViewModel(INavigation navigation){
            _navigation = navigation;
        }
    }
}
