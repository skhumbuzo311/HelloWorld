using System;

namespace SmartAutoSpares.Models.Applications
{
    public partial class Signature
    {
        public int Id { get; set; }
        public string Initials { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
