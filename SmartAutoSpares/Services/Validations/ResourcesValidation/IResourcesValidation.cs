using SmartAutoSpares.Entities;

namespace SmartAutoSpares.Services.Validations.ResourcesValidation
{
    public interface IResourcesValidation
    {
        (bool canAction, string error) CanAddFolder(Models.Folder addFolder);
        (bool canAction, string error) HasAdminPermissions(int userId);
        (bool canAction, string error) CanDeleteFolder(int userId, int folderId);
    }
}
