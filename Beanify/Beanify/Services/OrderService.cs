using System;
using System.Collections.Generic;
using System.Net.Http;
using Beanify.Models;
using Beanify.RestClients;
using Beanify.Serialization;

namespace Beanify.Services
{
    public class OrderService : BaseService<AppOrderModel>, IOrderService
    {
        private string uri = "api/OrderModels";

        public HttpResponseMessage AddItem(IModel item)
        {
            try
            {
                return AddItem(item, uri);
            }
            catch (Exception e)
            {

                throw e;
            }
            
        }

        public List<AppOrderModel> GetOrders()
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
