using SmartAutoSpares.Entities.Applications;
using System.Collections.Generic;

namespace SmartAutoSpares.Models.Applications
{
    public partial class ApplicationComponent
    {
        public List<Grade> Grades { get; set; }
        public List<ApplicationStatus> ApplicationStatuses { get; set; }
    }
}
