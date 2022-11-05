using System;

namespace SmartAutoSpares.Entities.Applications
{
    public partial class DeclarationDetails
    {
        public int Id { get; set; }
        public int ApplicantDeclarationId { get; set; }
        public int BenifactorDeclarationId { get; set; }
        public DateTime CreatedAt { get; set; }

        public ApplicantDeclaration ApplicantDeclaration { get; set; }
        public BenifactorDeclaration BenifactorDeclaration { get; set; }
    }
}
