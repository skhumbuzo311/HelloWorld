using System;

namespace SmartAutoSpares.Models
{
    public partial class AutoSpareLike
    {
        public int Id { get; set; }
        public int AutoSpareId { get; set; }
        public int CreatedByUserId { get; set; }
        public string CreatedByUserFirstName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
