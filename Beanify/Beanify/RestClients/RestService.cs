
using Beanify.Models;
using Beanify.Utils.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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
            //var authData = string.Format("{0}:{1}", "oyadmin", "6yagsix8JrjAbzwy");
            //var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));

            //client = new HttpClient ();
            //client.MaxResponseContentBufferSize = 256000;
            //         client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
            client = new HttpClient();
            RestUrl = "http://93.113.111.183:80/BeanifyWebApp/" + name ;
        }

        #region methods

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
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
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
                    Debug.WriteLine(@"				TodoItem successfully saved.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
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
                    Debug.WriteLine(@"				TodoItem successfully deleted.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }
        }

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
                throw new Exception("Impossible to connect to the server. Please check your connection.");
            }
        }

        public async Task<bool> IsAdmin(string accessToken)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await client.GetStringAsync(RestUrl);

            //Debug.WriteLine(response);

            return Convert.ToBoolean(response);
        }

        public async Task ForgotPassword(T item)
        {
            var client = new HttpClient();
            string url = RestUrl;
            RestUrl = "http://93.113.111.183/BeanifyWebApp/MvcAccount/ForgotPassword";
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
                else Debug.WriteLine(@"Mail successfully not sent (lol).");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }

        }

        public async Task RequestWithSerializableParameter(T item, string restUrl)
        {
            var client = new HttpClient();
            RestUrl = restUrl;
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
                    Debug.WriteLine(@"Request successfully done.");
                }
                else Debug.WriteLine(@"Request failled...");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }
        }

        #endregion

    }
}
