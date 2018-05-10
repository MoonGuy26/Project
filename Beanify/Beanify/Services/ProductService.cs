using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Beanify.Models;
using Beanify.RestClients;
using Beanify.Serialization;

namespace Beanify.Services
{
    public class ProductService : BaseService, IProductService
    {
        public List<ProductModel> GetProducts()
        {
            try
            {
                RestService<ProductModel> restService = new RestService<ProductModel>("api/ProductModels");

                return restService.GetProductsAsync(LocalStorageSettings.AccessToken).Result;

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
