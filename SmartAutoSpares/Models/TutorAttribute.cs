using System;
using System.Collections.Generic;
using SmartAutoSpares.Entities.Paystack;

namespace SmartAutoSpares.Models
{
    public class TutorAttribute
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SubAccountId { get; set; }
        public int BankId { get; set; }
        public decimal Rate { get; set; }
        public decimal AverageRating { get; set; }
        public bool IsAvailable { get; set; }
        public int LikesCount { get; set; }
        public int DisLikesCount { get; set; }
        public DateTime CreatedAt { get; set; }

        public Bank Bank { get; set; }
        public virtual SubAccount SubAccount { get; set; }
        public virtual User User { get; set; }
        public virtual List<string> Subjects { get; set; }
    }
}
