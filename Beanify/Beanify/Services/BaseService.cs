﻿
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

        public async Task AddItem(IModel item,string path)
        {
            RestService restService = new RestService(path);
            await restService.SaveItemAsync(item, true);
        }

    }
}
