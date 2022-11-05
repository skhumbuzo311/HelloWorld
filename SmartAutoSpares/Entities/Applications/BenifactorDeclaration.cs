using System;

namespace SmartAutoSpares.Entities.Applications
{
    public partial class BenifactorDeclaration
    {
        public int Id { get; set; }
        public int SignatureId { get; set; }
        public string FullName { get; set; }
        public string IDORPassportNumber { get; set; }
        public DateTime CreatedAt { get; set; }

        public Signature Signature { get; set; }
    }
}
