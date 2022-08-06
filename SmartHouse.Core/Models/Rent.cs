using SmartHouse.Shared.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using SmartHouse.Shared.Core.Enums;

namespace SmartHouse.Core.Models
{
    public class Rent : AuditableEntity
    {
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaidDate { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }


        public Rent Create(Rent rent, string user)
        {
            Id = Guid.NewGuid().ToString();
            Name = rent.Name;
            Amount = rent.Amount;
            PaidDate = rent.PaidDate;
            UserId = user;
            RecordState = RecordState.Active;

            CreateAuditable(user);
            ModifiedAuditable(user);

            return this;
        }
        public Rent Update(Rent rent, string user)
        {
            Id = rent.Id;
            Name = rent.Name;
            Amount = rent.Amount;
            PaidDate = rent.PaidDate;
            UserId = user;
            RecordState = RecordState.Active;

            ModifiedAuditable(user);
            return this;
        }

        public Rent Delete(string user)
        {
            RecordState = RecordState.Removed;
            ModifiedAuditable(user);

            return this;
        }
    }
}
