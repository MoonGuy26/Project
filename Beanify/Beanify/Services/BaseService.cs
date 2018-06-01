using Beanify.RestClients;
using Beanify.Models;
using Beanify.Serialization;
using System.Net.Http;
using System;
using System.Collections.Generic;

namespace Beanify.Services
{
    public abstract class BaseService<T> : IBaseService<T>
    {
        
        public BaseService() { }


        public HttpResponseMessage AddItem(IModel item, string uri)
        {
            try
            {
                var restService = new RestService<IModel>(uri);
                return restService.SaveDataAsyncAccess(LocalStorageSettings.AccessToken, item).Result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<T> GetItems(string uri)
        {
            try
            {
                RestService<T> restService = new RestService<T>(uri);
                return restService.RefreshDataAsyncAccess(LocalStorageSettings.AccessToken).Result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
