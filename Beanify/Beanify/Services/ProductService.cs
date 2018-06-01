using System;
using System.Collections.Generic;
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

                return restService.RefreshDataAsyncAccess(LocalStorageSettings.AccessToken).Result;

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
