using SmartAutoSpares.Entities.Applications;
using System;

namespace SmartAutoSpares.Models.Applications
{
    public partial class Application
    {
        public int Id { get; set; }
        public int ApplicantId { get; set; }
        public int StudentDetailsId { get; set; }
        public int ApplicationStatusId { get; set; }
        public int ParentOrGuardianDetailsId { get; set; }
        public int AcademicHistoryId { get; set; }
        public int DeclarationDetailsId { get; set; }
        public DateTime CreatedAt { get; set; }

        public Grade Grade { get; set; }
        public User Applicant { get; set; }
        public ApplicationStatus ApplicationStatus { get; set; }
        public StudentDetails StudentDetails { get; set; }
        public ParentOrGuardianDetails ParentOrGuardianDetails { get; set; }
        public AcademicHistory AcademicHistory { get; set; }
        public DeclarationDetails DeclarationDetails { get; set; }
    }
}
