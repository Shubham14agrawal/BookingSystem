using Grpc.Core;
using MediatR;
using BookingService.Application.Commands;
using BookingService.Domain;
using BookingService.Grpc;

namespace BookingService.Grpc.Services
{
    public class BookingGrpcService : BookingService.BookingServiceBase
    {
        private readonly IMediator _mediator;
        public BookingGrpcService(IMediator mediator)
        {
            _mediator = mediator;
        }
        public override async Task<BookingResponse> CreateBooking(CreateBookingRequest request, ServerCallContext context)
        {
            var command = new CreateBookingCommand
            {
                MemberId = request.MemberId,
                InventoryItemId = request.InventoryItemId
            };

            Booking booking = await _mediator.Send(command);

            return new BookingResponse
            {
                Id = booking.Id,
                MemberId = booking.MemberId,
                InventoryItemId = booking.InventoryItemId,
                BookingReference = booking.BookingReference,
                BookingDateTime = booking.BookingDateTime.ToString("o"),
                IsCancelled = booking.IsCancelled
            };
        }
    }
}
