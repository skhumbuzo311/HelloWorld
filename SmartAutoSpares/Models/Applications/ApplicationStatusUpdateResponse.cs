using SmartAutoSpares.Entities.Applications;

namespace SmartAutoSpares.Models.Applications
{
    public partial class ApplicationStatusUpdateResponse
    {
        public int ApplicationId { get; set; }
        public ApplicationStatus ApplicationStatus { get; set; }
    }
}
