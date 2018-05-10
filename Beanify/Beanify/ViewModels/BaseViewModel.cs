using Beanify.Utils.Navigation;
using Beanify.Utils.Orientation;
using Beanify.Utils.UI;
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
        protected ScreenDimensions _screenSize;
        




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

        public ScreenDimensions ScreenSize
        {
            get { return _screenSize; }
            set { _screenSize = value;
                OnPropertyChanged(nameof(ScreenSize));
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
            ScreenSize.ScreenWidth = Application.Current.MainPage.Width;
            ScreenSize.ScreenHeight = Application.Current.MainPage.Height;
            OnPropertyChanged(nameof(ScreenSize));
            Debug.WriteLine(ScreenOrientation);
            Debug.WriteLine(ScreenSize.ScreenWidth);
            Debug.WriteLine(ScreenSize.ScreenHeight);
        }

        protected virtual void InitializeViewModel()
        {
            Commands = new Dictionary<string, ICommand>();
            Commands.Add("SizeChanged", new Command(OnSizeChangedExecute));
            ScreenSize= new ScreenDimensions();
        }

        public virtual Task InitializeAsync(object navigationData)
        {
            return Task.FromResult(false);
        }


    }
}
