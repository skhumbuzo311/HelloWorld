using System;

namespace SmartAutoSpares.Models.Applications
{
    public partial class AcademicHistory
    {
        public int Id { get; set; }
        public string LastSchoolAttended { get; set; }
        public string Year { get; set; }
        public string Country { get; set; }
        public string Aggregate { get; set; }
        public string ApplicantLatestSchoolReportFileURL { get; set; }
        public string LatestGradeLevelComplete { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
