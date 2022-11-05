using System;
using System.Collections.Generic;

namespace SmartAutoSpares.Entities
{
    public class Folder
    {
        public int Id { get; set; }
        public int CreatedByUserId { get; set; }
        public int ParentFolderId { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }

        public User CreatedByUser { get; set; }
    }
}
