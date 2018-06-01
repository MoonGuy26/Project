using Beanify.Models;
using System.Collections.Generic;

namespace Beanify.Services
{
    public interface IProductService
    {
        List<ProductModel> GetProducts();
    }
}
