
using Beanify.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace Beanify.RestClients
{
    public interface IRestService<T>
    {
        Task<List<T>> RefreshDataAsync();

        Task SaveItemAsync(T item, bool isNewItem);



        Task DeleteItemAsync(string id);
    }
}
