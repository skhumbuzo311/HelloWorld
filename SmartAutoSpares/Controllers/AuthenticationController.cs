using Microsoft.AspNetCore.Mvc;
using SmartAutoSpares.Models;
using SmartAutoSpares.Outcomes;
using SmartAutoSpares.Outcomes.Results;
using SmartAutoSpares.Services.Authentication;
using System;
using System.Net;

namespace SmartAutoSpares.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authentication;
        private readonly IHandler _outcomeHandler;
        public AuthenticationController(IAuthenticationService authentication, IHandler outcomeHandler)
        {
            _authentication = authentication;
            _outcomeHandler = outcomeHandler;
        }

        [HttpPost("login")]
        public ActionResult<IOutcome<User>> PostLogin(User user)
        {
            return _outcomeHandler.HandleOutcome(_authentication.login(user));
        }

        [HttpPost("signup")]
        public ActionResult<IOutcome<SignupResponse>>  PostSignup(User user)
        {
            return _outcomeHandler.HandleOutcome(_authentication.signup(user));
        }
    }
}
