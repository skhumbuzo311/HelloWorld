using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using SmartAutoSpares.Entities;
using SmartAutoSpares.Outcomes;
using SmartAutoSpares.Outcomes.Results;
using SmartAutoSpares.Services.Bookings;
using SmartAutoSpares.Services.Settings;

namespace SmartAutoSpares.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotificationsController : ControllerBase
    {
        private readonly IHandler _outcomeHandler;
        private readonly INotificationsService _notificationsService;
        private readonly ICartService _bookingsService;
        public NotificationsController(ICartService bookingsService, INotificationsService notificationsService, IHandler outcomeHandler)
        {
            _outcomeHandler = outcomeHandler;
            _bookingsService = bookingsService;
            _notificationsService = notificationsService;
        }

        [HttpPut("update-user-expo-push-token")]
        public ActionResult<IOutcome> UpdateUserExpoPushToken(User user)
        {
            return _outcomeHandler.HandleOutcome(_notificationsService.UpdateUserExpoPushToken(user));
        }

        [HttpGet("admins-expo-push-tokens")]
        public List<string> GetAdminsExpoPushTokens()
        {
            return _notificationsService.GetAdminsExpoPushTokens();
        }
    }
}
