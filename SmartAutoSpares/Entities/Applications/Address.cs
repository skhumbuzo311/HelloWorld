using System;

namespace SmartAutoSpares.Entities.Applications
{
    public partial class Address
    {
        public int Id { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string PostalCode { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
