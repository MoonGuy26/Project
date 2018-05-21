using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beanify.Services
{
    public interface IAccountService
    {
        Task AddUser(string email, string password, string confirmPassword);
        Task<string> LoginUser(string email, string password);
        Task<bool> IsAdmin(string accessToken);
        Task<bool> IsAuthenticated(string accessToken);
        Task ForgottenPassword(string email);

    }
}
