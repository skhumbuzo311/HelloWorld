using System;
using System.Collections.Generic;

#nullable disable

namespace SmartAutoSpares.Entities
{
    public partial class CartItem
    {
        public CartItem()
        {
            OrderedItems = new HashSet<OrderedItem>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public int StatusId { get; set; }
        public int TotalCost { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsPaymentComplete { get; set; }
        public DateTime? PaymentCompletedAt { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual User User { get; set; }
        public virtual CartItemStatus Status { get; set; }
        public virtual ICollection<OrderedItem> OrderedItems { get; set; }
    }
}
