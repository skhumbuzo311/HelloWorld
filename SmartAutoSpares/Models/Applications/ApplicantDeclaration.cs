using Microsoft.AspNetCore.Http;
using System;

namespace SmartAutoSpares.Models.Applications
{
    public partial class ApplicantDeclaration
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string IDORBirthCertificateNumber { get; set; }
        public DateTime CreatedAt { get; set; }

        public Signature ApplicantSignature { get; set; }
        public Signature WitnessSignature { get; set; }
        public Signature ParentOrGuardianSignature { get; set; }
    }
}
