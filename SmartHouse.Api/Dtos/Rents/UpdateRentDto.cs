using SmartHouse.Shared.Core.Enums;
using System;

namespace SmartHouse.Api.Dtos.Rents
{
    public class UpdateRentDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaidDate { get; set; }
        public RentTypes RentType { get; set; }
    }
}
