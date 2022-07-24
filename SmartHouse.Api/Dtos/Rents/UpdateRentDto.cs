using System;

namespace SmartHouse.Api.Dtos.Rents
{
    public class UpdateRentDto
    {
        public string Id { get; set; }
        public Decimal Amount { get; set; }
        public DateTime PaidDate { get; set; }
    }
}
