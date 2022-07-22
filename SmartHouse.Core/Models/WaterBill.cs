using SmartHouse.Shared.Core.Models;
using SmartHouse.Shared.Core.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace SmartHouse.Core.Models
{
    public class WaterBill : AuditableEntity
    {
        public string AccountNumber  { get; set; }
        public Decimal Amount  { get; set; }
        public Decimal Arrears  { get; set; }
        public DateTime BillDate { get; set; }
        public string UserId  { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        

        public WaterBill Create(WaterBill waterBill) {
            AccountNumber = waterBill.AccountNumber;
            Amount = waterBill.Amount;
            Arrears = waterBill.Arrears;
            BillDate = waterBill.BillDate; 
            UserId = waterBill.UserId;
            RecordState = RecordState.Active;

            return this;
        }
        public WaterBill Update(WaterBill waterBill) {
            AccountNumber = waterBill.AccountNumber;
            Amount = waterBill.Amount;
            Arrears = waterBill.Arrears;
            BillDate = waterBill.BillDate;
            UserId = waterBill.UserId;
            RecordState = RecordState.Active;

            return this;
        }

        public WaterBill Delete(string bill)
        {
            RecordState = RecordState.Removed;

            ModifiedAuditable(bill);

            return this;
        }
    }
}
