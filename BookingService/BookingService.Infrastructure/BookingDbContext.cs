using Microsoft.EntityFrameworkCore;
using BookingService.Domain;
using System.Collections.Generic;

namespace BookingService.Infrastructure
{
    public class BookingDbContext : DbContext
    {
        public BookingDbContext(DbContextOptions<BookingDbContext> options)
        : base(options) { }

        public DbSet<Booking> Bookings { get; set; }
    }
}
