using Beanify.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Beanify.Services
{
    public interface IOrderService
    {
       HttpResponseMessage AddItem(IModel item);
       Task OrderConfirmation(IModel item);
    }
}
