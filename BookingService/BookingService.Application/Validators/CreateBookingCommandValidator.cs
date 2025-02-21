using FluentValidation;
using BookingService.Application.Commands;
using BookingService.Application.Clients;
using BookingService.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace BookingService.Application.Validators;

public class CreateBookingCommandValidator : AbstractValidator<CreateBookingCommand>
{
    private const int MAX_BOOKINGS = 2;

    public CreateBookingCommandValidator(IBookingRepository bookingRepository, IInventoryServiceClient inventoryClient)
    {
        RuleFor(x => x.MemberId)
            .GreaterThan(0)
            .WithMessage("MemberId must be greater than 0.")
            .MustAsync(async (memberId, cancellation) =>
            {
                int activeBookings = await bookingRepository.CountActiveBookingsAsync(memberId, cancellation);
                return activeBookings < MAX_BOOKINGS;
            })
            .WithMessage($"Member has reached the maximum of {MAX_BOOKINGS} active bookings.");

        RuleFor(x => x.InventoryItemId)
            .GreaterThan(0)
            .WithMessage("InventoryItemId must be greater than 0.")
            .MustAsync(async (inventoryItemId, cancellation) =>
            {
                return await inventoryClient.IsInventoryAvailableAsync(inventoryItemId);
            })
            .WithMessage("Inventory item is not available.");
    }
}
