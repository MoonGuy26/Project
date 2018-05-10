using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Beanify.iOS.Utils.Renderers;
using Beanify.Views;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(HomeCarouselView), typeof(HomeCarouselViewRenderer))]
namespace Beanify.iOS.Utils.Renderers
{
    public class HomeCarouselViewRenderer : PageRenderer
    {
        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            UIDevice.CurrentDevice.SetValueForKey(NSNumber.FromNInt((int)(UIInterfaceOrientation.Portrait)), new NSString("orientation"));

        }
        public override void ViewWillDisappear(bool animated)
        {
            base.ViewWillDisappear(animated);
            UIDevice.CurrentDevice.SetValueForKey(NSNumber.FromNInt((int)(UIInterfaceOrientation.Unknown)), new NSString("orientation"));
        }
    }
}