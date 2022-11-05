using System.Linq;
using System.Threading.Tasks;
using SmartAutoSpares.Context;
using SmartAutoSpares.Entities;
using SmartAutoSpares.Outcomes.Results;
using Microsoft.AspNetCore.SignalR;
using SmartAutoSpares.Hubs.Cart;
using SmartAutoSpares.Hubs.Notifications;
using System;
using System.Collections.Generic;

namespace SmartAutoSpares.Services.Settings
{
    public class NotificationsService : INotificationsService
    {
        private readonly SmartAutoSparesDbContext _focusMentorshipDbContext;
        private readonly IHubContext<NotificationsHub, INotificationsHub> _notificationsHub;

        public NotificationsService(SmartAutoSparesDbContext focusMentorshipDbContext, IHubContext<NotificationsHub, INotificationsHub> notificationsHub)
        {
            _focusMentorshipDbContext = focusMentorshipDbContext;
            _notificationsHub = notificationsHub;
        }

        public IOutcome UpdateUserExpoPushToken(User user)
        {
            try
            {
                var currentUser = _focusMentorshipDbContext.Users.Single(u => u.Id == user.Id);
                currentUser.ExpoPushToken = user.ExpoPushToken;

                _focusMentorshipDbContext.SaveChanges();

                return new Success();
            }
            catch (Exception ex)
            {
                return new Failure(ex.Message);
            }
        }

        public List<string> GetAdminsExpoPushTokens() => _focusMentorshipDbContext
            .Users
            .Where(u => u.IsAdmin)
            .Select(u => u.ExpoPushToken)
            .ToList();
    }
}
