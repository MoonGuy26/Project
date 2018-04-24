
using Beanify.RestClients;
using Beanify.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Beanify.Services
{
    public class AccountService : BaseService
    {
        public AccountService(string namePath="Account/Register") : base(namePath)
        {
            
        }

        public async Task AddUser(string email, string password, string confirmPassword)
        {
            RestService restService = new RestService(_namePath);

            var model = new RegisterBindingModel
            {
                Email = email,
                Password = password,
                ConfirmPassword = confirmPassword
            };

            await restService.SaveItemAsync(model, true);

        }

        public async Task<string> LoginUser(string email, string password)
        {
            try
            {
                RestService restService = new RestService(_namePath);
            
                var keyValues = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string,string>("username",email),
                    new KeyValuePair<string, string>("password",password),
                    new KeyValuePair<string, string>("grant_type","password")
                };

               return await restService.LoginAsync(keyValues);

            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> IsAdmin(string accessToken)
        {
            RestService restService = new RestService("api/Account/IsUserAdmin");

            var isAdmin =  await restService.IsAdmin(accessToken);

            return isAdmin;
        }
    }
}
