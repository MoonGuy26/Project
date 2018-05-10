
using Beanify.RestClients;
using Beanify.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Beanify.Services
{
    public class AccountService :BaseService, IAccountService
    {
        public AccountService() : base()
        {
            
        }

        public async Task AddUser(string email, string password, string confirmPassword)
        {
            RestService<RegisterBindingModel> restService = new RestService<RegisterBindingModel>("");

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

        public async Task<bool> IsAdmin(string accessToken)
        {
            RestService<object> restService = new RestService<object>("api/Account/IsUserAdmin");

            var isAdmin =  await restService.IsAdmin(accessToken);

            return isAdmin;
        }

        public async Task ForgottenPassword(string email)
        {
            RestService<ForgotPasswordViewModel> restService = new RestService<ForgotPasswordViewModel>("api/Account/ForgotPassword");

            /*var model = new ForgotPasswordBindingModel
            {
                Email = email
            };*/

            var model2 = new ForgotPasswordViewModel
            {
                Email = email
            };

            await restService.ForgotPassword(model2);
        }
    }
}
