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
        public Task<List<IModel>> GetProducts()
        {
            try
            {
                RestService restService = new RestService("api/ProductModels");

                return restService.RefreshDataAsync();

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
