using System.Linq;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using SmartAutoSpares.Context;
using SmartAutoSpares.Entities;

namespace SmartAutoSpares.Hubs.Feeds
{
    public class AutoSparesHub : Hub<IAutoSparesHub>
    {
        private readonly SmartAutoSparesDbContext _focusMentorshipDbContext;

        public AutoSparesHub(SmartAutoSparesDbContext focusMentorshipDbContext)
        {
            _focusMentorshipDbContext = focusMentorshipDbContext;
        }

        public async Task Add(Models.AutoSpare autoSpare)
        {
            await Clients.All.Add(autoSpare);
        }

        public async Task Update(Models.AutoSpare autoSpare)
        {
            await Clients.All.Update(autoSpare);
        }

        public async Task Delete(int id)
        {
            await Clients.All.Delete(id);
        }

        public async Task Like(Models.AutoSpareLike autoSpareLike)
        {
            await Clients.All.Like(autoSpareLike);
        }

        public async Task CommentAdded(PostComment comment)
        {
            comment = _focusMentorshipDbContext.PostComments
                .Include(c => c.CreatedByUser)
                .SingleOrDefault(c => c.Id == comment.Id);

            await Clients.All.PostComment(comment);
        }
    }
}
