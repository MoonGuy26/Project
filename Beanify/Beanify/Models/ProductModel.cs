namespace Beanify.Models
{
    public class ProductModel : AbstractBaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string imagePath;
        public string ImagePath
        {
            get { return imagePath; }
            set {
                imagePath = System.IO.Path.Combine("http://93.113.111.183:80/BeanifyWebApp/", value.Substring(2).Replace("\\\\" , "/"));   
            }
        }
    }
}
