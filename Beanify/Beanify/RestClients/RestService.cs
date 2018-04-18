﻿
using Beanify.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AgendApp.RestClients
{
    public class RestService : IRestService
    {
        HttpClient client;

        public List<IModel> Items { get; private set; }

        private string RestUrl;


        public RestService(string name)
        {
            //var authData = string.Format("{0}:{1}", "oyadmin", "6yagsix8JrjAbzwy");
            //var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));

            //client = new HttpClient ();
            //client.MaxResponseContentBufferSize = 256000;
            //         client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeaderValue);
            client = new HttpClient();
            RestUrl = "http://93.113.111.183:80/BeanifyWebApp/api/" + name + "/";
        }

        public async Task<List<IModel>> RefreshDataAsync()
        {
            Items = new List<IModel>();


            var uri = new Uri(string.Format(RestUrl, string.Empty));

            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<List<IModel>>(content);

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"				ERROR {0}", ex.Message);
            }

            return Items;
        }

        public async Task SaveItemAsync(IModel item, bool isNewItem = false)
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

        public async Task DeleteItemAsync(int id)
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
    }
}
