using System;

namespace SmartHouse.Api.Dtos.Rents
{
    public class RentDto
    {
        public Decimal Amount { get; set; }
        public DateTime PaidDate { get; set; }
        public string UserId { get; set; }
        public virtual UserRentDto User { get; set; }
    }

    public class UserRentDto {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
