using SmartHouse.Shared.Core.Models;
using SmartHouse.Shared.Core.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace SmartHouse.Core.Models
{
    public class WaterBill : AuditableEntity
    {
        public string AccountNumber  { get; set; }
        public decimal Amount  { get; set; }
        public decimal Arrears  { get; set; }
        public DateTime BillDate { get; set; }
        public string UserId  { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        

        public WaterBill Create(WaterBill waterBill, string user) {
            Id = Guid.NewGuid().ToString();
            AccountNumber = waterBill.AccountNumber;
            Amount = waterBill.Amount;
            Arrears = waterBill.Arrears;
            BillDate = waterBill.BillDate; 
            UserId = user;
            RecordState = RecordState.Active;

            CreateAuditable(user);
            ModifiedAuditable(user);

            return this;
        }
        public WaterBill Update(WaterBill waterBill, string user) {
            Id = waterBill.Id;
            AccountNumber = waterBill.AccountNumber;
            Amount = waterBill.Amount;
            Arrears = waterBill.Arrears;
            BillDate = waterBill.BillDate;
            UserId = waterBill.UserId;

            ModifiedAuditable(user);
            return this;
        }

        public WaterBill Delete(string user)
        {
            RecordState = RecordState.Removed;
            ModifiedAuditable(user);

            return this;
        }
    }
}
