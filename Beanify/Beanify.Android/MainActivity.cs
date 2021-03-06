﻿using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Lottie.Forms.Droid;
using HockeyApp.Android;
using CarouselView.FormsPlugin.Android;

using FFImageLoading.Forms.Droid;
using Xamarin.Forms;
using Beanify.Views;

namespace Beanify.Droid
{
    [Activity(Label = "Beanify", Icon = "@drawable/icon", Theme = "@style/MyTheme.Splash",
        MainLauncher = true, 
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            FormsPlugin.Iconize.Droid.IconControls.Init(Resource.Id.toolbar);
            Plugin.Iconize.Iconize.With(new Plugin.Iconize.Fonts.FontAwesomeModule())
                                  .With(new Plugin.Iconize.Fonts.MaterialModule());

            base.OnResume();
            CrashManager.Register(this, "7f70a56f74af4103ae0b13417235f1f9");

            Rg.Plugins.Popup.Popup.Init(this, bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            CarouselViewRenderer.Init();
            CachedImageRenderer.Init(true);

            AnimationViewRenderer.Init();

            MessagingCenter.Subscribe<HomeCarouselView>(this, "allowLandScapePortrait", sender =>
            {
                RequestedOrientation = ScreenOrientation.Unspecified;
            });

            //during page close setting back to portrait
            MessagingCenter.Subscribe<HomeCarouselView>(this, "preventLandScape", sender =>
            {
                RequestedOrientation = ScreenOrientation.Portrait;
            });

            

            LoadApplication(new App());
        }
        
        

        
    }
}

