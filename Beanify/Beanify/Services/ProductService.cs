using System;
using System.Collections.Generic;
using Beanify.Models;

namespace Beanify.Services
{
    public class ProductService : BaseService<ProductModel>, IProductService
    {
        private string uri = "api/ProductModels";

        public List<ProductModel> GetProducts()
        {
            try
            {
                return GetItems(uri);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
