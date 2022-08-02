using SmartHouse.Shared.Core.Enums;
using SmartHouse.Shared.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SmartHouse.Core.Models
{
    public class Garbage : AuditableEntity
    {
        public DateTime CollectingDate { get; set; }
        public GarbageTypes GarbageType { get; set; }
        public string Weight { get; set; }
        public string UserId { get; set; }
       
        [ForeignKey("UserId")]
        public User User { get; set; }

        public Garbage Create(Garbage garbage, string user) {
            Id = Guid.NewGuid().ToString();
            CollectingDate = garbage.CollectingDate;
            GarbageType = garbage.GarbageType;
            Weight = garbage.Weight;
            UserId = user;
            RecordState = RecordState.Active;

            CreateAuditable(user);
            ModifiedAuditable(user);
            return this;
        }

        public Garbage Update(Garbage garbage, string user)
        {
            Id = garbage.Id;
            CollectingDate = garbage.CollectingDate;
            GarbageType = garbage.GarbageType;
            Weight = garbage.Weight;
            UserId = user;

            ModifiedAuditable(user);
            return this;
        }

        public Garbage Delete(string user)
        {
            RecordState = RecordState.Removed;
            ModifiedAuditable(user);

            return this;
        }


    }
}
