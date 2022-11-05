using System;

namespace SmartAutoSpares.Entities.Applications
{
    public partial class Grade
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsOpenForApplications { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
