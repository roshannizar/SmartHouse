using SmartHouse.Shared.Api.Dtos;
using SmartHouse.Shared.Core.Enums;
using System;

namespace SmartHouse.Api.Dtos.Rents
{
    public class RentDto
    {
        public string Id { get; set; } 
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public RentTypes RentType { get; set; }
        public DateTime PaidDate { get; set; }
        public string UserId { get; set; }
        public virtual BaseUserDto User { get; set; }
    }
}
