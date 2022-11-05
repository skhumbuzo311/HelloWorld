 using System;
using System.Linq;
using SmartAutoSpares.Context;
using SmartAutoSpares.Entities;
using SmartAutoSpares.Outcomes.Results;
using SmartAutoSpares.Services.Validations.AuthenticationValidation;
using SmartAutoSpares.Services.Utils;
using SmartAutoSpares.Services.Converters;
using SmartAutoSpares.Hubs.Notifications;
using Microsoft.AspNetCore.SignalR;

namespace SmartAutoSpares.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly string _encryptionKey;
        private readonly SmartAutoSparesDbContext _smartAutoPartsDbContext;
        private readonly IAuthenticationValidation _authenticationValidation;
        private readonly IHubContext<NotificationsHub, INotificationsHub> _notificationsHub;
        public AuthenticationService(IHubContext<NotificationsHub, INotificationsHub> notificationsHub,SmartAutoSparesDbContext focusMentorshipDbContext, IAuthenticationValidation authenticationValidation)
        {
            _smartAutoPartsDbContext = focusMentorshipDbContext;
            _authenticationValidation = authenticationValidation;
            _notificationsHub = notificationsHub;

            var encryptionKey = _smartAutoPartsDbContext.Configurations.SingleOrDefault(c => c.Name == "Encryption key");
            if (encryptionKey == null) throw new Exception("Encryption key configuration value is missing.");

            _encryptionKey = encryptionKey.Value;
        }

        public IOutcome<Models.SignupResponse> signup(Models.User user)
        {
            (bool canAction, string error) = _authenticationValidation.CanAddUser(user);
            if (!canAction)
            {
                return new Failure<Models.SignupResponse>(error);
            }

            var newUser = new User()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                EmailAddress = user.EmailAddress,
                PhoneNumber = user.PhoneNumber,
                Password = Encryption.Encrypt(_encryptionKey, user.Password),
                IsActive = true,
                LastLoggedIn = DateTime.Now,
                CreatedAt = DateTime.Now
            };

            _smartAutoPartsDbContext.Users.Add(newUser);
            _smartAutoPartsDbContext.SaveChanges();

            return new Success<Models.SignupResponse>(new Models.SignupResponse() {
                User = AuthenticationConverter.ConvertUserToModel(newUser),
                AdminsExpoPushTokens = _smartAutoPartsDbContext.Users
                    .Where(u => u.IsAdmin)
                    .Select(u => u.ExpoPushToken)
                    .ToList()
            });
        }

        public IOutcome<Models.User> login(Models.User user)
        {
            var dbUser = _smartAutoPartsDbContext.Users.FirstOrDefault(u => u.PhoneNumber.ToLower() == user.PhoneNumber.ToLower() || u.EmailAddress.ToLower() == user.EmailAddress.ToLower());

            (bool canAction, string error) = _authenticationValidation.CanUserLogin(dbUser, user, _encryptionKey);
            if (!canAction)
            {
                return new Failure<Models.User>(error);
            }

            dbUser.LastLoggedIn = DateTime.Now;

            _smartAutoPartsDbContext.SaveChanges();

            return new Success<Models.User>(AuthenticationConverter.ConvertUserToModel(dbUser));
        }
    }
}
