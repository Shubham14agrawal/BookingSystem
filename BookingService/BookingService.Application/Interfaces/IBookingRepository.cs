using System.Threading;
using System.Threading.Tasks;
using BookingService.Domain;

namespace BookingService.Application.Interfaces
{
    public interface IBookingRepository
    {
        Task<int> CountActiveBookingsAsync(int memberId, CancellationToken cancellationToken);
        Task<bool> IsActiveBookingsAsync(int bookingId, CancellationToken cancellationToken);
        Task AddBookingAsync(Booking booking, CancellationToken cancellationToken);
        Task<Booking> CancelBookingAsync(int bookingId, CancellationToken cancellationToken);
    }
}
