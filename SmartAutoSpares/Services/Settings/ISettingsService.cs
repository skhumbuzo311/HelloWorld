using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartAutoSpares.Context;
using SmartAutoSpares.Entities;
using SmartAutoSpares.Outcomes.Results;

namespace SmartAutoSpares.Services.Settings
{
    public interface ISettingsService
    {
        Task<IOutcome<User>> UpdateAvatar(Microsoft.AspNetCore.Http.HttpRequest httpRequest);
        IOutcome<User> UpdateUser(User user);
    }
}
