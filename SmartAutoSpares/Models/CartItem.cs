using System;
using System.Collections.Generic;

#nullable disable

namespace SmartAutoSpares.Models
{
    public partial class CartItem
    {
        public CartItem()
        {
            OrderedItems = new HashSet<AutoSpare>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string Status { get; set; }
        public int TotalCost { get; set; }
        public DateTime? PaymentCompletedAt { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual User User { get; set; }
        public IEnumerable<string> imagesUrls { get; set; }
        public virtual IEnumerable<AutoSpare> OrderedItems { get; set; }
    }
}
