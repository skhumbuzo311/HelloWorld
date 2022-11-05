using System;

namespace SmartAutoSpares.Models
{
    public class Folder
    {
        public int Id { get; set; }
        public int CreatedByUserId { get; set; }
        public string Name { get; set; }
        public int ParentFolderId { get; set; }
        public DateTime CreatedAt { get; set; }

        public bool IsSubFolder
        {
            get
            {
                return ParentFolderId != 0;
            }
        }
    }
}
