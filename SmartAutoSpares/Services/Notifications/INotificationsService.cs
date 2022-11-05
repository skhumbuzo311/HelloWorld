using System.Collections.Generic;
using SmartAutoSpares.Entities;
using SmartAutoSpares.Outcomes.Results;

namespace SmartAutoSpares.Services.Settings
{
    public interface INotificationsService
    {
        IOutcome UpdateUserExpoPushToken(User user);
        List<string> GetAdminsExpoPushTokens();
    }
}
