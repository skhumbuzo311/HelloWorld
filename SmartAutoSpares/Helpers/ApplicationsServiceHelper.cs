using SmartAutoSpares.Entities.Applications;
using System;

namespace SmartAutoSpares.Helpers
{
    public static class ApplicationsServiceHelper
    {
        public static StudentDetails CreateStudentDetails(Models.Applications.StudentDetails studentDetails)
        {
            return new StudentDetails()
            {
                FirstName = studentDetails.FirstName,
                LastName = studentDetails.LastName,
                IDORBirthCertificateNumber = studentDetails.IDORBirthCertificateNumber,
                TelHome = studentDetails.TelHome,
                Fax = studentDetails.Fax,
                Cell = studentDetails.Cell,
                Email = studentDetails.Email,
                Title = studentDetails.Title,
                Race = studentDetails.Race,
                OtherRace = studentDetails.OtherRace,
                Gender = studentDetails.Gender,
                DisabilitiesOrMedicalConditionAffectStudies = studentDetails.DisabilitiesOrMedicalConditionAffectStudies,
                NatureOfDisabilityOrMedicalCondition = studentDetails.NatureOfDisabilityOrMedicalCondition,
                IDORBirthCertificateURL = studentDetails.ApplicantIDORBirthCertificateURL,
                CreatedAt = DateTime.Now,
                PostalAddress = CreateAddress(studentDetails.PostalAddress),
                ResidentialAddress = CreateAddress(studentDetails.ResidentialAddress)
            };
        }

        public static ParentOrGuardianDetails CreateParentOrGuardianDetails(Models.Applications.ParentOrGuardianDetails parentOrGuardianDetails)
        {
            return new ParentOrGuardianDetails()
            {
                Relationship = parentOrGuardianDetails.Relationship,
                IDNumber = parentOrGuardianDetails.IDNumber,
                TelHome = parentOrGuardianDetails.TelHome,
                TelWork = parentOrGuardianDetails.TelWork,
                Cell = parentOrGuardianDetails.Cell,
                Email = parentOrGuardianDetails.Email,
                IDORPassportURL = parentOrGuardianDetails.ParentOrGuardianIDORPassportFileURL,
                CreatedAt = DateTime.Now,
                PostalAddress = CreateAddress(parentOrGuardianDetails.PostalAddress),
                ResidentialAddress = CreateAddress(parentOrGuardianDetails.ResidentialAddress)
            };
        }

        public static AcademicHistory CreateAcademicHistory(Models.Applications.AcademicHistory academicHistory)
        {
            return new AcademicHistory()
            {
                LastHighSchoolAttended = academicHistory.LastSchoolAttended,
                Year = academicHistory.Year,
                Country = academicHistory.Country,
                Aggregate = academicHistory.Aggregate,
                LatestGradeLevelCompleted = academicHistory.LatestGradeLevelComplete,
                LatestSchoolReportURL = academicHistory.ApplicantLatestSchoolReportFileURL,
                CreatedAt = DateTime.Now
            };
        }

        public static Address CreateAddress(Address address)
        {
            return new Address()
            {
               Line1 = address.Line1,
               Line2 = address.Line2,
               Line3 = address.Line3,
               PostalCode = address.PostalCode,
               CreatedAt = DateTime.Now,
            };
        }

        public static DeclarationDetails CreateDeclarationDetails(Models.Applications.DeclarationDetails declarationDetails)
        {
            return new DeclarationDetails()
            {
                ApplicantDeclaration = CreateApplicantDeclaration(declarationDetails.ApplicantDeclaration),
                BenifactorDeclaration = CreateBenifactorDeclaration(declarationDetails.BenifactorDeclaration),
                CreatedAt = DateTime.Now
            };
        }

        public static ApplicantDeclaration CreateApplicantDeclaration(Models.Applications.ApplicantDeclaration applicantDeclaration)
        {
            return new ApplicantDeclaration()
            {
                FullName = applicantDeclaration.FullName,
                IDORBirthCertificateNumber = applicantDeclaration.IDORBirthCertificateNumber,
                CreatedAt = DateTime.Now,
                ApplicantSignature = new Signature()
                {
                    Initials = applicantDeclaration.ApplicantSignature.Initials,
                    CreatedAt = DateTime.Now
                },
                WitnessSignature = new Signature()
                {
                    Initials = applicantDeclaration.WitnessSignature.Initials,
                    CreatedAt = DateTime.Now
                },
                ParentOrGuardianSignature = new Signature()
                {
                    Initials = applicantDeclaration.ParentOrGuardianSignature.Initials,
                    CreatedAt = DateTime.Now
                }
            };
        }

        public static BenifactorDeclaration CreateBenifactorDeclaration(Models.Applications.BenifactorDeclaration benifactorDeclaration)
        {
            return new BenifactorDeclaration()
            {
                FullName = benifactorDeclaration.FullName,
                IDORPassportNumber = benifactorDeclaration.IDORPassportNumber,
                CreatedAt = DateTime.Now,
                Signature = new Signature()
                {
                    Initials = benifactorDeclaration.Signature.Initials,
                    CreatedAt = DateTime.Now
                }
            };
        }
    }
}
