using Beanify.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
namespace Beanify.RestClients
{
    public interface IRestService<T>
    {
        #region CRUD Methods
        Task<List<T>> RefreshDataAsync();
        Task<List<T>> RefreshDataAsyncAccess(string accessToken);

        Task SaveItemAsync(T item, bool isNewItem);
        Task<HttpResponseMessage> SaveDataAsyncAccess(string accessToken, IModel orderModel);

        Task DeleteItemAsync(string id);
        #endregion

        Task<string> LoginAsync(List<KeyValuePair<string, string>> logs);

        Task<bool> IsAuthenticated(string accessToken);

        Task ForgotPassword(T item);
    }
}
