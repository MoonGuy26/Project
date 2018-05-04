using Beanify.Utils.Navigation;
using Beanify.Utils.Orientation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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
        protected double _screenWidth;
        protected double _screenHeight;




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

        public double ScreenWidth
        {
            get { return _screenWidth; }
            set { _screenWidth = value;
                OnPropertyChanged(nameof(ScreenWidth));
            }
        }
        public double ScreenHeight
        {
            get { return _screenHeight; }
            set
            {
                _screenHeight = value;
                OnPropertyChanged(nameof(ScreenHeight));
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
            ScreenWidth = Application.Current.MainPage.Width;
            ScreenHeight = Application.Current.MainPage.Height;
            Debug.WriteLine(ScreenOrientation);
            Debug.WriteLine(ScreenWidth);
            Debug.WriteLine(ScreenHeight);
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
