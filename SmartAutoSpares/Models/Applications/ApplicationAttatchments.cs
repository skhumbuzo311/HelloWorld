using Microsoft.AspNetCore.Http;

namespace SmartAutoSpares.Models.Applications
{
    public partial class ApplicationAttachments
    {
        public IFormFile ApplicantIDORBirthCertificateFile { get; set; }
        public IFormFile ParentOrGuardianIDORPassportFile { get; set; }
        public IFormFile ApplicantLatestSchoolReportFile { get; set; }
    }
}
