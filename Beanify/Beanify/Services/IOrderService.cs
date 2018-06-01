using Beanify.Models;
using System.Collections.Generic;
using System.Net.Http;

namespace Beanify.Services
{
    public interface IOrderService
    {
       HttpResponseMessage AddItem(IModel item);
       List<AppOrderModel> GetOrders();
    }
}
