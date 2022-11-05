using System.Linq;
using System.Text.RegularExpressions;
using SmartAutoSpares.Context;
using SmartAutoSpares.Entities;
using SmartAutoSpares.Services.Utils;

namespace SmartAutoSpares.Services.Validations.AuthenticationValidation
{
    public class AuthenticationValidation : IAuthenticationValidation
    {
        private readonly SmartAutoSparesDbContext _focusMentorshipDbContext;

        public AuthenticationValidation(SmartAutoSparesDbContext focusMentorshipDbContext)
        {
            _focusMentorshipDbContext = focusMentorshipDbContext;
        }

        public (bool canAction, string error) CanAddUser(Models.User user)
        {
            if (string.IsNullOrEmpty(user.FirstName))
            {
                return (false, "Please enter a valid first name.");
            }

            if (string.IsNullOrEmpty(user.LastName))
            {
                return (false, "Please enter a valid last name.");
            }

            if (!new Regex(Constants.PhoneNumberValidationRegex).Match(user.PhoneNumber).Success)
            {
                return (false, "Please enter a valid phone number.");
            }

            if (!new Regex(Constants.EmailValidationRegex).Match(user.EmailAddress).Success)
            {
                return (false, "Please enter a valid email address.");
            }

            if (user.Password.Length < 4)
            {
                return (false, "Password must at least be 4 charactors in length.");
            }

            if (_focusMentorshipDbContext.Users.Any(u => u.PhoneNumber.ToLower() == user.PhoneNumber.ToLower()))
            {
                return (false, $"User with phone number {user.PhoneNumber} already exists");
            }

            if (_focusMentorshipDbContext.Users.Any(u => u.EmailAddress.ToLower() == user.EmailAddress.ToLower()))
            {
                return (false, $"User with email {user.EmailAddress} already exists");
            }

            return (true, string.Empty);
        }

        public (bool canAction, string error) CanUserLogin(User dbUser, Models.User user, string encryptionKey)
        {
            if (dbUser == null)
            {
                return (false, $"No user exists with phone number {user.PhoneNumber}, please create new account.");
            }

            if (!user.IsPasswordEncrypted && Encryption.Decrypt(encryptionKey, dbUser.Password) != user.Password)
            {
                return (false, $"Password incorrect.");
            }

            if (user.IsPasswordEncrypted && user.Password != dbUser.Password)
            {
                return (false, $"Password incorrect.");
            }

            return (true, string.Empty);
        }
    }
}
