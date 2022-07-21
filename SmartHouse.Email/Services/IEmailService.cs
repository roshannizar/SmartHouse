using System.Threading.Tasks;

namespace SmartHouse.Email.Services
{
    public interface IEmailService
    {
        Task SendVerification(string email, string token);
        Task SendForgotPasswordLink(string email, string token);
    }
}
