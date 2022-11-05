using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using SmartAutoSpares.Entities;

namespace SmartAutoSpares.Hubs.Cart
{
    public class CartHub : Hub<ICartHub>
    {
        public async Task NewBooking(int bookingId)
        {
            await Clients.All.NewBooking(bookingId);
        }

        public async Task CancelBookingPayment(int bookingId)
        {
            await Clients.All.CancelBookingPayment(bookingId);
        }

        public async Task CompleteBookingPayment(int bookingId)
        {
            await Clients.All.CompleteBookingPayment(bookingId);
        }

        public async Task BookingAccepted(int bookingId)
        {
            await Clients.All.BookingAccepted(bookingId);
        }

        public async Task BookingRejected(int bookingId, string rejectMessage)
        {
            await Clients.All.BookingRejected(bookingId, rejectMessage);
        }
    }
}
