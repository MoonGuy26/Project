using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Beanify.Utils.Navigation
{
    public  class NavigationSerializer
    {
        public async Task SerializeNavigationStack()
        {
            if (!Application.Current.Properties.ContainsKey("nav_saved"))
            {
                Application.Current.Properties.Add("nav_saved", "true");
                await Application.Current.SavePropertiesAsync();
            }


            IList <Page> jsonType = new List<Page>();
            int i = 0;
            foreach(Page p in Application.Current.MainPage.Navigation.NavigationStack)
            {
                string key = "app_navigation" + i.ToString();
                if (Application.Current.Properties.ContainsKey(key))
                {
                    Application.Current.Properties[key] = JsonConvert.SerializeObject(jsonType);
                }

                else
                    Application.Current.Properties.Add(key, JsonConvert.SerializeObject(jsonType));
            }

            

            await Application.Current.SavePropertiesAsync();
        }

        public  void DeserializeNavigationStack()
        {
            int i = 0;
            bool isLast = false;
            string key;
            while (!isLast)
            {
                key = "app_navigation" + i.ToString();
                if (Application.Current.Properties.ContainsKey(key))
                {

                    string typeString = (string)Application.Current.Properties[key];
                    Page page = JsonConvert.DeserializeObject<Page>(typeString);
                    
                    Application.Current.MainPage.Navigation.PushAsync(page);
                    
                    i++;
                }
                else
                {
                    isLast = true;
                }
            }
           
        }

    }
}
