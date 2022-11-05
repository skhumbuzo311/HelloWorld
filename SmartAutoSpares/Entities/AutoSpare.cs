using System;
using System.Collections.Generic;

namespace SmartAutoSpares.Entities
{
    public partial class AutoSpare
    {
        public AutoSpare()
        {
            Likes = new HashSet<AutoSpareLike>();
            Images = new HashSet<AutoSpareImage>();
        }

        public int Id { get; set; }
        public int CreatedByUserId { get; set; }
        public string Name { get; set; }
        public string Make { get; set; }
        public string YearModel { get; set; }
        public string Number { get; set; }
        public int Price { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual User CreatedByUser { get; set; }
        public virtual ICollection<AutoSpareLike> Likes { get; set; }
        public virtual ICollection<AutoSpareImage> Images { get; set; }
    }
}
