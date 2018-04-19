
using Beanify.RestClients;
using Beanify.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beanify.Services
{
    public abstract class BaseService
    {
        protected string _namePath;

        public BaseService(string namePath)
        {
            _namePath = namePath;
        }

        public async Task AddItem(IModel item)
        {
            RestService restService = new RestService(_namePath);
            await restService.SaveItemAsync(item, true);
        }

    }
}
