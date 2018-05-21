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
            try
            {
                var restService = new RestService<IModel>("api/OrderModels");
                return restService.SaveOrderAsync(LocalStorageSettings.AccessToken, item).Result;
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
                RestService<AppOrderModel> restService = new RestService<AppOrderModel>("api/OrderModels/GetFromUser");

                return restService.GetOrdersAsync(LocalStorageSettings.AccessToken).Result;

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
