using MediatR;
using BookingService.Application.Commands;
using BookingService.Application.Clients;
using BookingService.Application.Interfaces;
using BookingService.Domain;
using FluentValidation;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace BookingService.Application.Handlers
{
    public class CancelBookingCommandHandler : IRequestHandler<CancelBookingCommand, Booking>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IInventoryServiceClient _inventoryClient;
        private readonly IValidator<CancelBookingCommand> _validator;

        public CancelBookingCommandHandler(
            IBookingRepository bookingRepository,
            IInventoryServiceClient inventoryClient,
            IValidator<CancelBookingCommand> validator)
        {
            _bookingRepository = bookingRepository;
            _inventoryClient = inventoryClient;
            _validator = validator;
        }

        public async Task<Booking> Handle(CancelBookingCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request, cancellationToken);
            var booking = await _bookingRepository.CancelBookingAsync(request.Id, cancellationToken);

            if (!await _inventoryClient.IncreaseInventoryAsync(booking.InventoryItemId))
                throw new Exception("Failed to update inventory.");
            return booking;
        }
    }
}
