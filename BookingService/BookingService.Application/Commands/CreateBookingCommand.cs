using MediatR;
using BookingService.Domain;

namespace BookingService.Application.Commands;

public class CreateBookingCommand : IRequest<Booking>
{
    public int MemberId { get; set; }
    public int InventoryItemId { get; set; }
}
