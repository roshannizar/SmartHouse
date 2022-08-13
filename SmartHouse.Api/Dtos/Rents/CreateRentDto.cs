﻿using SmartHouse.Shared.Core.Enums;
using System;

namespace SmartHouse.Api.Dtos.Rents
{
    public class CreateRentDto
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaidDate { get; set; }
        public RentTypes RentType { get; set; }
          
    }
}
