
using Beanify.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgendApp.RestClients
{
    public interface IRestService
    {
        Task<List<IModel>> RefreshDataAsync();

        Task SaveItemAsync(IModel item, bool isNewItem);



        Task DeleteItemAsync(int id);
    }
}
