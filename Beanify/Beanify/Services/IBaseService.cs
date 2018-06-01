using Beanify.Models;
using Beanify.RestClients;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Beanify.Services
{
    public interface IBaseService<T>
    {

        HttpResponseMessage AddItem(IModel item, string uri);
        List<T> GetItem(string uri);
    }
}
