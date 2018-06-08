using System;
using System.Collections.Generic;
using System.Text;

namespace Beanify
{
    public class Settings
    {
        public readonly static Settings Default = new Settings();

        public string HttpRoute { get
            {
                return "http://app.beanify.com/";
            }
        } 
    }
}
