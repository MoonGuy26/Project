using System;
using System.Collections.Generic;
using System.Net.Http;
using Beanify.Models;

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
                return GetItems(uri);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
