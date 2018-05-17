using System;
using System.Collections.Generic;
using System.Linq;
using Beanify.Views;
using CarouselView.FormsPlugin.iOS;
using FFImageLoading.Forms.Touch;
using Foundation;
using HockeyApp.iOS;
using Lottie.Forms.iOS.Renderers;
using UIKit;

namespace Beanify.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Rg.Plugins.Popup.Popup.Init(this, bundle);
            FormsPlugin.Iconize.iOS.IconControls.Init();
            Plugin.Iconize.Iconize.With(new Plugin.Iconize.Fonts.FontAwesomeModule())
                                  .With(new Plugin.Iconize.Fonts.MaterialModule());

            var manager = BITHockeyManager.SharedHockeyManager;
            manager.Configure("68bc18fcb44a43a3978f485db8f2fe09");
            manager.StartManager();
            manager.Authenticator.AuthenticateInstallation();
            global::Xamarin.Forms.Forms.Init();
            CarouselViewRenderer.Init();
            CachedImageRenderer.Init();
            LoadApplication(new App());

            AnimationViewRenderer.Init();
            

            return base.FinishedLaunching(app, options);
        }

        public override UIInterfaceOrientationMask GetSupportedInterfaceOrientations(UIApplication application, UIWindow forWindow)
        {
            var mainPage = Xamarin.Forms.Application.Current.MainPage;
            if (mainPage.Navigation.NavigationStack.Last() is HomeCarouselView)
            {
                return UIInterfaceOrientationMask.AllButUpsideDown;
            }
            return UIInterfaceOrientationMask.Portrait;
        }
    }
}
