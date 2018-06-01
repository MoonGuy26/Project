using Beanify.Models;
using System.Collections.Generic;
using System.Net.Http;

namespace Beanify.Services
{
    public interface IBaseService<T>
    {
        HttpResponseMessage AddItem(IModel item, string uri);
        List<T> GetItems(string uri);
    }
}
