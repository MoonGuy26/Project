
using AgendApp.RestClients;
using Beanify.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AgendApp.Services
{
    public class RegisterUserService : BaseService
    {
        public RegisterUserService(string namePath="Account/Register") : base(namePath)
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
    }
}
