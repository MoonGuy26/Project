using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Beanify.Models;
using Beanify.RestClients;
using Beanify.Serialization;

namespace Beanify.Services
{
    public class OrderService : IOrderService
    {
        public HttpResponseMessage AddItem(IModel item)
        {
            var restService = new RestService<IModel>("api/OrderModels");
            return restService.SaveOrderAsync(LocalStorageSettings.AccessToken, item).Result;
        }

        public List<OrderModel> GetOrder()
        {
            try
            {
                RestService<OrderModel> restService = new RestService<OrderModel>("api/OrderModels/GetFromUser");

                return restService.GetOrdersAsync(LocalStorageSettings.AccessToken).Result;

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
