using Beanify.Utils.Navigation;
using Beanify.Utils.Orientation;
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
        protected StackOrientation _screenOrientation;

        public StackOrientation ScreenOrientation
        {
            get { return _screenOrientation; }
            set
            {
                if (_screenOrientation != value)
                {
                    _screenOrientation = value;
                    OnPropertyChanged(nameof(ScreenOrientation));
                }
            }
        }

        public Dictionary<string, ICommand> Commands { get; protected set; }

        public BaseViewModel()
        {
            InitializeViewModel();
            var viewModelLocator = new ViewModelLocator();
            _navigationService = viewModelLocator.NavigationService;
        }

        protected void OnSizeChangedExecute()
        {
            var orientation = DependencyService.Get<IDeviceOrientation>().GetOrientation();
            switch (orientation)
            {
                case DeviceOrientations.Undefined:

                    break;
                case DeviceOrientations.Landscape:
                    ScreenOrientation = StackOrientation.Horizontal;
                    break;
                case DeviceOrientations.Portrait:
                    ScreenOrientation = StackOrientation.Vertical;
                    break;
            }

            //Debug.WriteLine(ScreenOrientation);
        }

        protected virtual void InitializeViewModel()
        {
            Commands = new Dictionary<string, ICommand>();
            Commands.Add("SizeChanged", new Command(OnSizeChangedExecute));
        }

        public virtual Task InitializeAsync(object navigationData)
        {
            return Task.FromResult(false);
        }


    }
}
