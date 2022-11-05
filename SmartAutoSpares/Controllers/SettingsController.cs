using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SmartAutoSpares.Entities;
using SmartAutoSpares.Outcomes;
using SmartAutoSpares.Outcomes.Results;
using SmartAutoSpares.Services.Settings;

namespace SmartAutoSpares.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SettingsController : ControllerBase
    {
        private readonly IHandler _outcomeHandler;
        private readonly ISettingsService _settingsService;
        public SettingsController(ISettingsService settingsService, IHandler outcomeHandler)
        {
            _settingsService = settingsService;
            _outcomeHandler = outcomeHandler;
        }

        [HttpPut("update-avatar")]
        public async Task<ActionResult<IOutcome<User>>> UpdateAvatar()
        {
            return _outcomeHandler.HandleOutcome(await _settingsService.UpdateAvatar(Request)); ;
        }

        [HttpPut("update-user")]
        public ActionResult<IOutcome<User>> UpdateUser(User user)
        {
            return _outcomeHandler.HandleOutcome(_settingsService.UpdateUser(user)); ;
        }
    }
}
