using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using SmartAutoSpares.Context;
using Microsoft.EntityFrameworkCore;


namespace SmartAutoSpares.Services.Validations.ResourcesValidation
{
    public class ResourcesValidation : IResourcesValidation
    {
        private readonly SmartAutoSparesDbContext _focusMentorshipDbContext;

        public ResourcesValidation(SmartAutoSparesDbContext focusMentorshipDbContext)
        {
            _focusMentorshipDbContext = focusMentorshipDbContext;
        }

        public (bool canAction, string error) CanAddFolder(Models.Folder addFolder)
        {
            var folders = _focusMentorshipDbContext.Folders.ToList();

            if (folders.Any(f => f.Name.ToLower() == addFolder.Name.ToLower() && f.ParentFolderId == addFolder.ParentFolderId))
            {
                return (false, $"Folder name with name {addFolder.Name} already exists.");
            }

            if (!addFolder.IsSubFolder && addFolder.Name.Length < 2)
            {
                return (false, $"Folder name should atleast be 2 letters in length.");
            }

            if (addFolder.IsSubFolder && addFolder.Name.Length < 3)
            {
                return (false, $"Folder name should atleast be 3 letters in length.");
            }

            if (addFolder.IsSubFolder && addFolder.Name.Length < 3)
            {
                return (false, $"Folder name should atleast be 3 letters in length.");
            }

            if(!_focusMentorshipDbContext.Users.Any(u => u.Id == addFolder.CreatedByUserId && u.IsAdmin))
            {
                return (false, $"You do not have permissions to create a folder.");
            }

            return (true, string.Empty);
        }

        public (bool canAction, string error) CanDeleteFolder(int userId, int folderId)
        {
            if (_focusMentorshipDbContext.Folders.Any(u => u.ParentFolderId == folderId))
            {
                return (false, $"Contains subfolders, delete subfolders first.");
            }

            if (!_focusMentorshipDbContext.Users.Any(u => u.Id == userId && u.IsAdmin))
            {
                return (false, $"You do not have permissions for this action.");
            }

            return (true, string.Empty);
        }

        public (bool canAction, string error) HasAdminPermissions(int userId)
        {
            if (!_focusMentorshipDbContext.Users.Any(u => u.Id == userId && u.IsAdmin))
            {
                return (false, $"You do not have permissions for this action.");
            }

            return (true, string.Empty);
        }
    }
}
