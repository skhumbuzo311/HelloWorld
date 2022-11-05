using System;
using System.Collections.Generic;

namespace SmartAutoSpares.Entities
{
    public class OrderedItem
    {
        public int Id { get; set; }
        public int CartItemId { get; set; }
        public int AutoSpareId { get; set; }
        public bool IsDeleted { get; set; }

        public CartItem CartItem { get; set; }
        public AutoSpare AutoSpare { get; set; }
    }
}
