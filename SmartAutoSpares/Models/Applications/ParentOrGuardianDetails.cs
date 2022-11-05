using SmartAutoSpares.Entities.Applications;
using System;

namespace SmartAutoSpares.Models.Applications
{
    public partial class ParentOrGuardianDetails
    {
        public int Id { get; set; }
        public string Relationship { get; set; }
        public string IDNumber { get; set; }
        public string TelHome { get; set; }
        public string TelWork { get; set; }
        public string Cell { get; set; }
        public string Email { get; set; }
        public string ParentOrGuardianIDORPassportFileURL { get; set; }
        public DateTime CreatedAt { get; set; }

        public Address PostalAddress { get; set; }
        public Address ResidentialAddress { get; set; }
    }
}
