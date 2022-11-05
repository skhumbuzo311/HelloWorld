using System;
using System.Collections.Generic;

namespace SmartAutoSpares.Entities
{
    public class TutorLike
    {
        public int Id { get; set; }
        public int CreatedByUserId { get; set; }
        public bool IsDislike { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
