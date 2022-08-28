using SmartHouse.Shared.Api.Dtos;

namespace SmartHouse.Api.Dtos.Utilities
{
    public class UtilityDto
    {
        public string Id { get; set; }
        public string AccountNumber { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; }
        public string UserId { get; set; }
        public virtual BaseUserDto User { get; set; }
    }
}
