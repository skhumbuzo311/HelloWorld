using System.Linq;
using SmartAutoSpares.Context;
using SmartAutoSpares.Outcomes.Results;
using Microsoft.Extensions.Configuration;
using ServiceLayer;
using SmartAutoSpares.Models.Applications;
using SmartAutoSpares.Helpers;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SmartAutoSpares.Services.Utils;

namespace SmartAutoSpares.Services.Applications
{
    public class ApplicationsService : IApplicationsService
    {
        private readonly SmartAutoSparesDbContext _focusMentorshipDbContext;
        private readonly IConfiguration _configuration;

        public ApplicationsService(SmartAutoSparesDbContext focusMentorshipDbContext, IConfiguration configuration)
        {
            _focusMentorshipDbContext = focusMentorshipDbContext;
            _configuration = configuration;
        }

        public IEnumerable<Entities.Applications.Application> Get() => _focusMentorshipDbContext.Applications
            .Include(a => a.Applicant)
            .Include(a => a.StudentDetails)
                .ThenInclude(sd => sd.ResidentialAddress)
             .Include(a => a.StudentDetails)
                .ThenInclude(sd => sd.PostalAddress)
            .Include(a => a.Grade)
            .Include(a => a.ApplicationStatus)
            .Include(a => a.ParentOrGuardianDetails)
                .ThenInclude(sd => sd.ResidentialAddress)
            .Include(a => a.ParentOrGuardianDetails)
                .ThenInclude(sd => sd.PostalAddress)
            .Include(a => a.AcademicHistory)
            .Include(a => a.DeclarationDetails)
                .ThenInclude(dd => dd.ApplicantDeclaration)
                    .ThenInclude(ad => ad.ApplicantSignature)
            .Include(a => a.DeclarationDetails)
                .ThenInclude(dd => dd.ApplicantDeclaration)
                    .ThenInclude(ad => ad.WitnessSignature)
            .Include(a => a.DeclarationDetails)
                .ThenInclude(dd => dd.ApplicantDeclaration)
                    .ThenInclude(ad => ad.ParentOrGuardianSignature)
            .Include(a => a.DeclarationDetails)
                .ThenInclude(dd => dd.BenifactorDeclaration)
                    .ThenInclude(ad => ad.Signature)
            .ToList();

        public ApplicationComponent GetApplicationComponents() => new ApplicationComponent()
        {
            Grades = _focusMentorshipDbContext.Grades.Where(g => g.IsOpenForApplications).ToList(),
            ApplicationStatuses = _focusMentorshipDbContext.ApplicationStatuses.ToList()
        };

        public IOutcome CreateApplication(Application application)
        {
            var applicationStatus = _focusMentorshipDbContext.ApplicationStatuses.Single(appStatus => appStatus.Name == "Awaiting Review");

            _focusMentorshipDbContext.Applications.Add(new Entities.Applications.Application()
            {
                ApplicantId = application.ApplicantId,
                StudentDetails = ApplicationsServiceHelper.CreateStudentDetails(application.StudentDetails),
                GradeId = application.Grade.Id,
                ApplicationStatusId = applicationStatus.Id,
                ParentOrGuardianDetails = ApplicationsServiceHelper.CreateParentOrGuardianDetails(application.ParentOrGuardianDetails),
                AcademicHistory = ApplicationsServiceHelper.CreateAcademicHistory(application.AcademicHistory),
                DeclarationDetails = ApplicationsServiceHelper.CreateDeclarationDetails(application.DeclarationDetails),
                CreatedAt = System.DateTime.Now
            });

            _focusMentorshipDbContext.SaveChanges();

            return new Success();
        }

        public async Task<IOutcome<ApplicationAttachmentsResponse>> PostAttathments(ApplicationAttachments aa)
        {
            BlobStorageService objBlobService = new BlobStorageService(_configuration);

            var AIDORBCFileData = await FormFileExtensions.GetBytes(aa.ApplicantIDORBirthCertificateFile);
            var PORGIDORPFileData = await FormFileExtensions.GetBytes(aa.ParentOrGuardianIDORPassportFile);
            var ALSRFFileData = await FormFileExtensions.GetBytes(aa.ApplicantLatestSchoolReportFile);

            return new Success<ApplicationAttachmentsResponse>(new ApplicationAttachmentsResponse()
            {
                ApplicantIDORBirthCertificateFileURL = objBlobService.UploadFileToBlob(aa.ApplicantIDORBirthCertificateFile.FileName, AIDORBCFileData, aa.ApplicantIDORBirthCertificateFile.ContentType),
                ParentOrGuardianIDORPassportFileURL = objBlobService.UploadFileToBlob(aa.ParentOrGuardianIDORPassportFile.FileName, PORGIDORPFileData, aa.ParentOrGuardianIDORPassportFile.ContentType),
                ApplicantLatestSchoolReportFileURL = objBlobService.UploadFileToBlob(aa.ApplicantLatestSchoolReportFile.FileName, ALSRFFileData, aa.ApplicantLatestSchoolReportFile.ContentType)
            });
        }

        public IOutcome<ApplicationStatusUpdateResponse> UpdateApplicationStatus(Application application)
        {
            var dbApplication = _focusMentorshipDbContext.Applications.Single(a => a.Id == application.Id);

            dbApplication.ApplicationStatusId = application.ApplicationStatus.Id;
            
            _focusMentorshipDbContext.SaveChanges();

            return new Success<ApplicationStatusUpdateResponse>(new ApplicationStatusUpdateResponse() {
                ApplicationId = application.Id,
                ApplicationStatus = application.ApplicationStatus
            });
        }
    }
}
