using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Beanify.Models;
using Beanify.RestClients;

namespace Beanify.Services
{
    public class ProductService : BaseService, IProductService
    {
        public Task<List<ProductModel>> GetProducts()
        {
            try
            {
                RestService<ProductModel> restService = new RestService<ProductModel>("api/ProductModels");

                return restService.RefreshDataAsync();

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
