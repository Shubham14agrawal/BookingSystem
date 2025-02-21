using MediatR;
using BookingService.Domain;

namespace BookingService.Application.Commands;

public class CancelBookingCommand : IRequest<Booking>
{
    public int Id { get; set; }
}
