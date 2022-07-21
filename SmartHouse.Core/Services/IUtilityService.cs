using SmartHouse.Core.Models;

namespace SmartHouse.Core.Services
{
    public interface IUtilityService
    {
        string GenerateToken(User user);
        string ValidateToken(string token);
    }
}
