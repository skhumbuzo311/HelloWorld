using System;

namespace SmartAutoSpares.Models.Applications
{
    public partial class DeclarationDetails
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }

        public ApplicantDeclaration ApplicantDeclaration { get; set; }
        public BenifactorDeclaration BenifactorDeclaration { get; set; }
    }
}
