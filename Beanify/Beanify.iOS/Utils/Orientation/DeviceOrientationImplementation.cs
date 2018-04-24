using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Beanify.iOS.Utils.Orientation;
using Beanify.Utils.Orientation;
using Foundation;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(DeviceOrientationImplementation))]
namespace Beanify.iOS.Utils.Orientation
{
    public class DeviceOrientationImplementation : IDeviceOrientation
    {
        public DeviceOrientationImplementation() { }

        public DeviceOrientations GetOrientation()
        {
            var currentOrientation = UIApplication.SharedApplication.StatusBarOrientation;
            bool isPortrait = currentOrientation == UIInterfaceOrientation.Portrait
                || currentOrientation == UIInterfaceOrientation.PortraitUpsideDown;

            return isPortrait ? DeviceOrientations.Portrait : DeviceOrientations.Landscape;
        }
    }
}