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
                _imagePath = System.IO.Path.Combine(Settings.Default.HttpRoute, value.Substring(2).Replace("\\\\" , "/"));   
            }
        }
        
    }
}
