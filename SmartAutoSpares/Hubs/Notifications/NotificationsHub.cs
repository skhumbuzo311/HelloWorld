using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SmartAutoSpares.Hubs.Notifications
{
    public class NotificationsHub : Hub<INotificationsHub>
    {
        public async Task BookingRequest(int bookingId, int tutorAttributeId)
        {
            await Clients.All.BookingRequest(bookingId, tutorAttributeId);
        }

        public async Task BookingPaymentRequest(int bookingId, int createdByUserId)
        {
            await Clients.All.BookingPaymentRequest(bookingId, createdByUserId);
        }

        public async Task StudentRatingTutor(int bookingId, int createdByUserId)
        {
            await Clients.All.StudentRatingTutor(bookingId, createdByUserId);
        }

        public async Task TutorRatingStudent(int bookingId, int tutorAttributeId)
        {
            await Clients.All.TutorRatingStudent(bookingId, tutorAttributeId);
        }
    }
}
