using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using SmartAutoSpares.Entities;

namespace SmartAutoSpares.Hubs.Tutors
{
    public class TutorsHub : Hub<ITutorsHub>
    {
        public async Task Like(TutorLike tutorLike)
        {
            await Clients.All.Like(tutorLike);
        }

        public async Task UpdateTutorAttribute(TutorAttribute tutorAttribute)
        {
            await Clients.All.UpdateTutorAttribute(tutorAttribute);
        }
    }
}
