using System;

namespace SmartAutoSpares.Entities
{
    public partial class TutorSubject
    {
        public int Id { get; set; }
        public int SubjectId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual Subject Subject { get; set; }
        // public virtual TutorAttribute TutorAttribute { get; set; }
    }
}
