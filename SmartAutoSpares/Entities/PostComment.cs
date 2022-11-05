using System;

namespace SmartAutoSpares.Entities
{
    public partial class PostComment
    {
        public int Id { get; set; }
        public int CreatedByUserId { get; set; }
        public int PostId { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual User CreatedByUser { get; set; }
    }
}
