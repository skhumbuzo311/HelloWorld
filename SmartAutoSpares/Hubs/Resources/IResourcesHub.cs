using System.Collections.Generic;
using System.Threading.Tasks;
using SmartAutoSpares.Entities;
using SmartAutoSpares.Models;

namespace SmartAutoSpares.Hubs.Feeds
{
    public interface IResourcesHub
    {
        Task ReceiveFolder(Models.Folder folder);
        Task RemoveFolder(int folderId);
        Task RemoveDocument(int folderId);
    }
}
