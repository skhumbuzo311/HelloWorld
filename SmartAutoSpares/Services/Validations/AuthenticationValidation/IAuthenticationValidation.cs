using SmartAutoSpares.Models;

namespace SmartAutoSpares.Services.Validations.AuthenticationValidation
{
    public interface IAuthenticationValidation
    {
        (bool canAction, string error) CanAddUser(User user);
        (bool canAction, string error) CanUserLogin(Entities.User dbUser, User user, string encryptionKey);
    }
}
