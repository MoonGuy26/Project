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
                _imagePath = System.IO.Path.Combine("http://93.113.111.183:80/BeanifyWebApp/", value.Substring(2).Replace("\\\\" , "/"));   
            }
        }
        
    }
}
