using System.Collections.Generic;
using System.Threading.Tasks;
using SmartAutoSpares.Models.Applications;
using SmartAutoSpares.Outcomes.Results;

namespace SmartAutoSpares.Services.Applications
{
    public interface IApplicationsService
    {
        IEnumerable<Entities.Applications.Application> Get();
        ApplicationComponent GetApplicationComponents();
        IOutcome CreateApplication(Application application);
        IOutcome<ApplicationStatusUpdateResponse> UpdateApplicationStatus(Application application);
        Task<IOutcome<ApplicationAttachmentsResponse>> PostAttathments(ApplicationAttachments applicationAttachments);
    }
}
