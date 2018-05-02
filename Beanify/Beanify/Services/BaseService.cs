
using Beanify.RestClients;
using Beanify.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beanify.Services
{
    public abstract class BaseService : IBaseService
    {
        
        public BaseService()
        {
            
        }


        public Task AddItem(IModel item)
        {
            var restService = new RestService<IModel>("api/"+item.GetType().ToString()+"s");
            return restService.SaveItemAsync(item, true);
        }

    }
}
