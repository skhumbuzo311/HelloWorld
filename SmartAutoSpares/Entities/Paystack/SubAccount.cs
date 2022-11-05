using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace SmartAutoSpares.Entities.Paystack
{
    public partial class SubAccount
    {
        public int Id { get; set; }
        public int PayStackId { get; set; }
        public string AccountNumber { get; set; }
        public bool? Active { get; set; }
        public int BankId { get; set; }
        public string BusinessName { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string Currency { get; set; }
        public string Domain { get; set; }
        public bool IsVerified { get; set; }
        public decimal PercentageCharge { get; set; }
        public string SettlementBank { get; set; }
        public string SettlementSchedule { get; set; }
        public string SubAccountCode { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
