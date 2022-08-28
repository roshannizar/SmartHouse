using SmartHouse.Shared.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using SmartHouse.Shared.Core.Enums;

namespace SmartHouse.Core.Models
{
    public class Utility : AuditableEntity
    {
        public string AccountNumber { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; }
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public Utility Create(Utility utility, string user)
        {
            Id = Guid.NewGuid().ToString();
            AccountNumber = utility.AccountNumber;
            Amount = utility.Amount;
            Type = utility.Type;
            UserId = user;
            RecordState = RecordState.Active;

            CreateAuditable(user);
            ModifiedAuditable(user);

            return this;
        }
        public Utility Update(Utility utility, string user)
        {
            Id = Guid.NewGuid().ToString();
            AccountNumber = utility.AccountNumber;
            Amount = utility.Amount;
            Type = utility.Type;
            UserId = utility.UserId;
            RecordState = RecordState.Active;

            ModifiedAuditable(user);
            return this;
        }

        public Utility Delete(string user)
        {
            RecordState = RecordState.Active;
            ModifiedAuditable(user);

            return this;
        }
    }
}
