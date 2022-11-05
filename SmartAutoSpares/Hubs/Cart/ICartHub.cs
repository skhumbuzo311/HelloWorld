using System.Threading.Tasks;
using SmartAutoSpares.Entities;

namespace SmartAutoSpares.Hubs.Cart
{
    public interface ICartHub
    {
        Task NewBooking(int bookingId);
        Task BookingAccepted(int bookingId);
        Task CancelBookingPayment(int bookingId);
        Task CompleteBookingPayment(int bookingId);
        Task BookingPaymentRequest(int bookingId, int studentId);
        Task BookingRejected(int bookingId, string rejectMessage);
        Task TutorRatingStudent(int bookingId, int rating, string comment);
        Task StudentRatingTutor(int bookingId, int rating, string comment);
    }
}
