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
    public class CreateBookingCommandHandler : IRequestHandler<CreateBookingCommand, Booking>
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IInventoryServiceClient _inventoryClient;
        private readonly IValidator<CreateBookingCommand> _validator;

        public CreateBookingCommandHandler(
            IBookingRepository bookingRepository,
            IInventoryServiceClient inventoryClient,
            IValidator<CreateBookingCommand> validator)
        {
            _bookingRepository = bookingRepository;
            _inventoryClient = inventoryClient;
            _validator = validator;
        }

        public async Task<Booking> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request, cancellationToken);

            var booking = new Booking
            {
                MemberId = request.MemberId,
                InventoryItemId = request.InventoryItemId,
                BookingDateTime = DateTime.UtcNow,
                IsCancelled = false
            };

            await _bookingRepository.AddBookingAsync(booking, cancellationToken);

                if (!await _inventoryClient.DecrementInventoryAsync(request.InventoryItemId))
                    throw new Exception("Failed to update inventory.");



            return booking;
        }
    }
}
