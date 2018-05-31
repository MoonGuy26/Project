﻿using System;
using Beanify.iOS.Utils.Renderers;
using Beanify.Views;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;


[assembly: ExportRenderer(typeof(NavigationPage), typeof(NavigationPageRenderer))]
namespace Beanify.iOS.Utils.Renderers
{
   
    public class NavigationPageRenderer : NavigationRenderer
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            NavigationBar.TopItem.TitleView = new UIImageView(UIImage.FromBundle("logo_sm.png"))
            {
                ContentMode = UIViewContentMode.Center,
                ContentScaleFactor = 2.5f
                                               
            };
            // Create the back arrow icon image
            var arrowImage = UIImage.FromBundle("back_arrow.png");
            NavigationBar.BackIndicatorImage = arrowImage;
            NavigationBar.BackIndicatorTransitionMaskImage = arrowImage;

            // Set the back button title to empty since Material Design doesn't use it.
            if (NavigationItem?.BackBarButtonItem != null)
                NavigationItem.BackBarButtonItem.Title = " ";
            if (NavigationBar.BackItem != null)
            {
                NavigationBar.BackItem.Title = " ";
                NavigationBar.BackItem.BackBarButtonItem.Image = arrowImage;
            }
        }
    }

}