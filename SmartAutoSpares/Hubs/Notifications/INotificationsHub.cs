using System.Threading.Tasks;

namespace SmartAutoSpares.Hubs.Notifications
{
    public interface INotificationsHub
    {
        Task BookingRequest(int bookingId, int tutorAttributeId);
        Task StudentRatingTutor(int bookingId, int createdByUserId);
        Task TutorRatingStudent(int bookingId, int tutorAttributeId);
        Task BookingPaymentRequest(int bookingId, int createdByUserId);
    }
}
