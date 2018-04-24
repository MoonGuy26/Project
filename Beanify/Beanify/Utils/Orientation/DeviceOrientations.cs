using System;
using System.Collections.Generic;
using System.Text;

namespace Beanify.Utils.Orientation
{
    public enum DeviceOrientations
    {
        Undefined,
        Landscape,
        Portrait
    }

    public interface IDeviceOrientation
    {
        DeviceOrientations GetOrientation();
    }
}
