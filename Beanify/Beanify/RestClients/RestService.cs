using Beanify.Models;
using Beanify.Serialization;
using Beanify.Utils.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Beanify.RestClients
{
    public class RestService<T> : IRestService<T>
    {
        HttpClient client;

        public List<T> Items { get; private set; }

        private string RestUrl;


        public RestService(string name)
        {
            client = new HttpClient();
            RestUrl = "http://93.113.111.183:80/BeanifyWebApp/" + name ;
        }

        #region methods

        #region CRUD Methods
        public async Task<List<T>> RefreshDataAsync()
        {
            Items = new List<T>();
            
            var uri = new Uri(string.Format(RestUrl, string.Empty));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<List<T>>(content);

                }
            }
            catch (Exception ex)
            {
                throw new Exception("Impossible to connect to the server. Please check your connection.");
            }

            return Items;
        }

        public async Task<List<T>> RefreshDataAsyncAccess(string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            try
            {

            HttpResponseMessage response = await client.GetAsync(RestUrl).ConfigureAwait(false);

            if (!response.IsSuccessStatusCode)
            {
                CheckUnauthorized(response);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", LocalStorageSettings.AccessToken);
                response = await client.GetAsync(RestUrl).ConfigureAwait(false);

            }
            var json = await response.Content.ReadAsStringAsync();

            Items = JsonConvert.DeserializeObject<List<T>>(json);
            }
            catch (Exception ex)
            {
                throw new ImpossibleServerConnectionException();
            }

            return Items;
        }

        public async Task SaveItemAsync(T item, bool isNewItem = false)
        {
            string url = RestUrl;
            var uri = new Uri(string.Format(RestUrl, string.Empty));

            try
            {
                
                var json = JsonConvert.SerializeObject(item);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    response = await client.PostAsync(uri, content);
                }
                else
                {
                    response = await client.PutAsync(uri, content);
                }

                if (response.IsSuccessStatusCode)
                {
                    Debug.Write(response);
                    Debug.WriteLine(@"TodoItem successfully saved.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }
        }

        public async Task<HttpResponseMessage> SaveDataAsyncAccess(string accessToken, IModel orderModel)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var json = JsonConvert.SerializeObject(orderModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            try
            {
                var response = await client.PostAsync(RestUrl, content).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    return response;
                }
                else
                {
                    Debug.Write(response.Content);
                    throw new UnsuccessfulStatusCodeException("An error has occurred during the ordering proccess. No order has been made.");
                }
            }
            catch (UnsuccessfulStatusCodeException)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new ImpossibleServerConnectionException();
            }
        }

        public async Task DeleteItemAsync(string id)
        {
            var uri = new Uri(string.Format(RestUrl, id));

            try
            {
                var response = await client.DeleteAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"TodoItem successfully deleted.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }
        }
        #endregion 

        public async Task<string> LoginAsync(List<KeyValuePair<string, string>> logs)
        {
            
            var request = new HttpRequestMessage(HttpMethod.Post, RestUrl);
            request.Content = new FormUrlEncodedContent(logs);

            var client = new HttpClient();

            try
            {
                var response = await client.SendAsync(request);
                if (response.IsSuccessStatusCode)
                {
                    var jwt = await response.Content.ReadAsStringAsync();

                    JObject jwtDynamic = JsonConvert.DeserializeObject<dynamic>(jwt);

                    var accessToken = jwtDynamic.Value<string>("access_token");
                    var accessTokenExpiration = jwtDynamic.Value<string>(".expires");

                    return accessToken;
                }
                else
                {
                    throw new UnsuccessfulStatusCodeException("The email or password you entered is incorrect.");
                }
            }
            catch (UnsuccessfulStatusCodeException)
            {
                throw;
            }
            catch(Exception e)
            {
                throw new ImpossibleServerConnectionException();
            }
        }

        public async Task<bool> IsAuthenticated(string accessToken)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            bool isAuthenticated = false;
            try
            {

           
            var requestTask =  client.GetAsync(RestUrl);
            var response = requestTask.GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                    isAuthenticated = Convert.ToBoolean(await response.Content.ReadAsStringAsync());

            }
            else
            {
                CheckUnauthorized(response);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", 
                    LocalStorageSettings.AccessToken);
                var secondRequestTask = client.GetAsync(RestUrl);
                HttpResponseMessage secondResponse = secondRequestTask.GetAwaiter().GetResult();
                if (secondResponse.IsSuccessStatusCode)
                {
                    isAuthenticated = Convert.ToBoolean(await secondResponse.Content.ReadAsStringAsync());
                }
                else
                {
                    return false;
                }

            }
            return true;
            }
            catch(Exception e)
            {
                throw new ImpossibleServerConnectionException();
            }


        }

        public async Task ForgotPassword(T item)
        {
            var client = new HttpClient();
            var uri = new Uri(string.Format(RestUrl, string.Empty));
            try
            {

                var json = JsonConvert.SerializeObject(item);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response1 = null;
                response1 = await client.PostAsync(uri, content);
                Debug.WriteLine(response1);
                if (response1.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"Mail successfully sent.");
                }
                else Debug.WriteLine(@"Mail successfully not sent.");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

        }

        #region private
        private void CheckUnauthorized(HttpResponseMessage response)
        {
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                RequestAccessToken(LocalStorageSettings.Email, LocalStorageSettings.Password);
            }
        }

        private async void RequestAccessToken(string email, string password)
        {
            var keyValues = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string,string>("username",email),
                    new KeyValuePair<string, string>("password",password),
                    new KeyValuePair<string, string>("grant_type","password")
                };
            LocalStorageSettings.AccessToken = await this.LoginAsync(keyValues);
        }
        #endregion

        #endregion



    }
}
