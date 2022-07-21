using SmartHouse.Core.Models;
using SmartHouse.Shared.Core.Helpers;
using SmartHouse.Shared.Core.Service;
using System.Threading.Tasks;

namespace SmartHouse.Core.Services
{
    public interface IUserService : IBaseService<User>
    {
        Task<string> Authenticate(string email, string password);
        Task<User> GetMetaDataAsync(string token);
        Task UpdatePasswordAsync(PasswordModel model, string token);
        Task ForgotPasswordAsync(string email);
        Task VerifyAccountAsync(string token);
        Task ResendVerificationAsync(string email);
    }
}
