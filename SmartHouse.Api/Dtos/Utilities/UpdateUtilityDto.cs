namespace SmartHouse.Api.Dtos.Utilities
{
    public class UpdateUtilityDto
    {
        public string Id { get; set; }
        public string AccountNumber { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; }
    }
}
