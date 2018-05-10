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

        public async Task OrderConfirmation(IModel item)
        {
            RestService<object> restService = new RestService<object>("api/OrderModels/OrderConfirmation");

            await restService.RequestWithSerializableParameter(item, LocalStorageSettings.AccessToken);
        }
    }
}
