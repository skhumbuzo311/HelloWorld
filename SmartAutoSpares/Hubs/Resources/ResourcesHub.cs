using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SmartAutoSpares.Hubs.Feeds
{
    public class ResourcesHub : Hub<IResourcesHub>
    {
        public async Task FolderAdded(Models.Folder folder)
        {
            await Clients.All.ReceiveFolder(folder);
        }
    }
}
