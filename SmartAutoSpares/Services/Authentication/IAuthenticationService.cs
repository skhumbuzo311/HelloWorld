
using SmartAutoSpares.Models;
using SmartAutoSpares.Outcomes.Results;

namespace SmartAutoSpares.Services.Authentication
{
    public interface IAuthenticationService
    {
        IOutcome<User> login(User user);
        IOutcome<SignupResponse> signup(User user);
    }
}
