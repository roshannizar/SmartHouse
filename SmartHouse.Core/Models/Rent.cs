using SmartHouse.Shared.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SmartHouse.Core.Models
{
    public class Rent : AuditableEntity
    {
        public Decimal Amount { get; set; }
        public DateTime PaidDate { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
