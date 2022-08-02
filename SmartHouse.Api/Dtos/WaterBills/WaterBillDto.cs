using SmartHouse.Shared.Api.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHouse.Api.Dtos.WaterBills
{
    public class WaterBillDto
    {
        public string Id { get; set; }
        public string AccountNumber { get; set; }
        public Decimal Amount { get; set; }
        public Decimal Arrears { get; set; }
        public DateTime BillDate { get; set; }
        public string UserId { get; set; }       
        public virtual BaseUserDto User { get; set; }
    }
}
