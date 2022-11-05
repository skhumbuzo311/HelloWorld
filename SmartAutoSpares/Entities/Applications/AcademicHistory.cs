using System;

namespace SmartAutoSpares.Entities.Applications
{
    public partial class AcademicHistory
    {
        public int Id { get; set; }
        public string LastHighSchoolAttended { get; set; }
        public string Year { get; set; }
        public string Country { get; set; }
        public string Aggregate { get; set; }
        public string LatestSchoolReportURL { get; set; }
        public string LatestGradeLevelCompleted { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
