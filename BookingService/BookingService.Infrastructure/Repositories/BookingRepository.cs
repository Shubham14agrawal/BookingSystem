using BookingService.Application.Interfaces;
using BookingService.Domain;
using BookingService.Infrastructure.Services;
using InventoryService.Protos;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace BookingService.Infrastructure.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly BookingDbContext _dbContext;
        public BookingRepository(BookingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CountActiveBookingsAsync(int memberId, CancellationToken cancellationToken)
        {
            return await _dbContext.Bookings.CountAsync(b => b.MemberId == memberId && !b.IsCancelled, cancellationToken);
        }
        public async Task<bool> IsActiveBookingsAsync(int bookingid, CancellationToken cancellationToken)
        {
            return await _dbContext.Bookings.AnyAsync(b => b.Id == bookingid && !b.IsCancelled, cancellationToken);
        }
        public async Task AddBookingAsync(Booking booking, CancellationToken cancellationToken)
        {
            _dbContext.Bookings.Add(booking);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
        public async Task<Booking> CancelBookingAsync(int bookingId, CancellationToken cancellationToken)
        {
            var booking = await _dbContext.Bookings.FirstAsync(b => b.Id == bookingId, cancellationToken);

            booking.IsCancelled = true;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return booking;
        }

    }
}
