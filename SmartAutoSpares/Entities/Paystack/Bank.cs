using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace SmartAutoSpares.Entities.Paystack
{
    public partial class Bank
    {
        public int Id { get; set; }
        public int PayStackId { get; set; }
        public bool? Active { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string Country { get; set; }
        public bool IsDeleted { get; set; }
        public string LongCode { get; set; }
        public string Name { get; set; }
        public bool? PayWithBank { get; set; }
        public string Slug { get; set; }
        public string Type { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
