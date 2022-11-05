using System;

namespace SmartAutoSpares.Entities
{
    public partial class AutoSpareImage
    {
        public int Id { get; set; }
        public int AutoSpareId { get; set; }
        public string URL { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
