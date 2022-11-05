using System;

namespace SmartAutoSpares.Entities
{
    public partial class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
