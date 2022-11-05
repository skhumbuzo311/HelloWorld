using System;
using System.Linq;
using System.Threading.Tasks;
using SmartAutoSpares.Context;
using SmartAutoSpares.Entities;
using SmartAutoSpares.Outcomes.Results;
using SmartAutoSpares.Services.Utils;
using ServiceLayer;
using Microsoft.Extensions.Configuration;

namespace SmartAutoSpares.Services.Settings
{
    public class SettingsService : ISettingsService
    {
        private readonly SmartAutoSparesDbContext _focusMentorshipDbContext;
        private readonly IConfiguration _configuration;

        public SettingsService(SmartAutoSparesDbContext focusMentorshipDbContext, IConfiguration configuration)
        {
            _focusMentorshipDbContext = focusMentorshipDbContext;
            _configuration = configuration;
        }

        public async Task<IOutcome<User>> UpdateAvatar(Microsoft.AspNetCore.Http.HttpRequest httpRequest)
        {
            var file = httpRequest.Form.Files[0];
            var hasImage = file != null;
            var imageHeight = httpRequest.Form["imageHeight"][0];
            var imageWidth = httpRequest.Form["imageWidth"][0];
            var currentUserId = int.Parse(httpRequest.Form["createdByUserId"][0]);
            var currentUser = _focusMentorshipDbContext.Users.Single(u => u.Id == currentUserId);
            var mimeType = file.ContentType;
            var fileData = await FormFileExtensions.GetBytes(file);
     
            BlobStorageService objBlobService = new BlobStorageService(_configuration);

            currentUser.HasAvatar = true;
            currentUser.ImageWidth = hasImage ? int.Parse(imageWidth) : 0;
            currentUser.ImageHeight = hasImage ? int.Parse(imageHeight) : 0;
            currentUser.AvatarURL = objBlobService.UploadFileToBlob(currentUser.PhoneNumber, fileData, mimeType);

            _focusMentorshipDbContext.Users.Update(currentUser);
            _focusMentorshipDbContext.SaveChanges();

            return new Success<User>(currentUser);
        }

        public IOutcome<User> UpdateUser(User user)
        {
            var currentUser = _focusMentorshipDbContext.Users.Single(u => u.Id == user.Id);
            currentUser.PhoneNumber = user.PhoneNumber;
            currentUser.Address = user.Address;

            _focusMentorshipDbContext.SaveChanges();

            return new Success<User>(currentUser);
        }
    }
}
