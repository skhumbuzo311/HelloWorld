using System;

namespace SmartAutoSpares.Entities.Applications
{
    public partial class StudentDetails
    {
        public int Id { get; set; }
        public int PostalAddressId { get; set; }
        public int ResidentialAddressId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IDORBirthCertificateNumber { get; set; }
        public string TelHome { get; set; }
        public string Fax { get; set; }
        public string Cell { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public string Race { get; set; }
        public string OtherRace { get; set; }
        public string Gender { get; set; }
        public string DisabilitiesOrMedicalConditionAffectStudies { get; set; }
        public string NatureOfDisabilityOrMedicalCondition { get; set; }
        public string IDORBirthCertificateURL { get; set; }
        public DateTime CreatedAt { get; set; }

        public Address PostalAddress { get; set; }
        public Address ResidentialAddress { get; set; }
    }
}
