using System;

namespace SmartHouse.Api.Dtos.Rents
{
    public class CreateRentDto
    {
        public Decimal Amount { get; set; }
        public DateTime PaidDate { get; set; }
    }
}
