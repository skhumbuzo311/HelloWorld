using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SmartAutoSpares.Outcomes;
using SmartAutoSpares.Outcomes.Results;
using SmartAutoSpares.Services.Applications;
using SmartAutoSpares.Models.Applications;
using Microsoft.AspNetCore.Http;

namespace SmartAutoSpares.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApplicationsController : ControllerBase
    {
        private readonly IHandler _outcomeHandler;
        private readonly IApplicationsService _applicationsService;
        public ApplicationsController(IApplicationsService applicationsService, IHandler outcomeHandler)
        {
            _applicationsService = applicationsService;
            _outcomeHandler = outcomeHandler;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_applicationsService.Get());
        }

        [HttpGet("components")]
        public ActionResult GetApplicationComponents()
        {
            return Ok(_applicationsService.GetApplicationComponents());
        }

        [HttpPost("attatchments-to-urls")]
        public async Task<ActionResult<IOutcome<ApplicationAttachmentsResponse>>> PostAttathments([FromForm] ApplicationAttachments attatchments)
        {
            return _outcomeHandler.HandleOutcome(await _applicationsService.PostAttathments(attatchments));
        }

        [HttpPost]
        public ActionResult<IOutcome> CreateApplication(Application application)
        {
            return _outcomeHandler.HandleOutcome(_applicationsService.CreateApplication(application));
        }

        [HttpPatch("application-status")]
        public ActionResult<IOutcome<ApplicationStatusUpdateResponse>> UpdateApplicationStatus(Application application)
        {
            return _outcomeHandler.HandleOutcome(_applicationsService.UpdateApplicationStatus(application));
        }
    }
}
