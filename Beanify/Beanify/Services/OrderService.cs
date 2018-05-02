using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Beanify.Models;
using Beanify.RestClients;

namespace Beanify.Services
{
    public class OrderService : IOrderService
    {
        public Task AddItem(IModel item)
        {
            var restService = new RestService<IModel>("api/OrderModels");
            return restService.SaveItemAsync(item, true);
        }
    }
}
