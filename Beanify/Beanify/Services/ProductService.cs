using System;
using System.Collections.Generic;
using Beanify.Models;
using Beanify.RestClients;
using Beanify.Serialization;

namespace Beanify.Services
{
    public class ProductService : BaseService<ProductModel>,IProductService
    {
        private string uri = "api/ProductModels";

        public List<ProductModel> GetProducts()
        {
            try
            {
                return GetItem(uri);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
