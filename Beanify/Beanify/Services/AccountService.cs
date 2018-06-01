using Beanify.RestClients;
using Beanify.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Beanify.Serialization;

namespace Beanify.Services
{
    public class AccountService : IAccountService
    {
        public AccountService(){ }

        public async Task<string> LoginUser(string email, string password)
        {
            try
            {
                LocalStorageSettings.Email = email;
                LocalStorageSettings.Password = password;

                RestService<object> restService = new RestService<object>("Token");
            
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

        public async Task<bool> IsAuthenticated(string accessToken)
        {
            try
            {
                RestService<object> restService = new RestService<object>("api/Account/IsAuthenticated");

                var isAuthenticated = await restService.IsAuthenticated(accessToken);

                return isAuthenticated;
            }
           catch(Exception e)
            {
                throw e;
            }
        }

        public async Task ForgottenPassword(string email)
        {
            RestService<ForgotPasswordViewModel> restService = new RestService<ForgotPasswordViewModel>("MvcAccount/ForgotPassword");

            var model = new ForgotPasswordViewModel
            {
                Email = email
            };

            await restService.ForgotPassword(model);
        }
    }
}
