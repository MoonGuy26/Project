using System.Threading.Tasks;

namespace Beanify.Services
{
    public interface IAccountService
    {
        Task<string> LoginUser(string email, string password);
        Task<bool> IsAuthenticated(string accessToken);
        Task ForgottenPassword(string email);

    }
}
