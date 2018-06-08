

using System;
using Xamarin.Forms;

namespace Beanify.Models
{
    public class ProductModel : AbstractBaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        private string _imagePath;
        public string ImagePath
        {
            get { return _imagePath; }
            set {
                _imagePath = System.IO.Path.Combine(Settings.Default.HttpRoute, value.Substring(2).Replace("\\" , "/"));
                
                Picture= new UriImageSource
                {
                    Uri = new System.Uri(_imagePath),
                    CachingEnabled = true,
                    CacheValidity = new TimeSpan(0, 0, 5, 0)
                };
            }
        }
        public ImageSource Picture { get; set; }
      
    }
}
