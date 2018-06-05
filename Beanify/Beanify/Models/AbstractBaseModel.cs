namespace Beanify.Models
{
    public abstract class AbstractBaseModel:IModel
    {
        public int Id { get; set; }
        public bool IsFirst { get; set; }
    }
}
