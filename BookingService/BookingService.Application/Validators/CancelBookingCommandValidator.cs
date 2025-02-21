using FluentValidation;
using BookingService.Application.Commands;
using BookingService.Application.Clients;
using BookingService.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace BookingService.Application.Validators;

public class CancelBookingCommandValidator : AbstractValidator<CancelBookingCommand>
{
    public CancelBookingCommandValidator(IBookingRepository bookingRepository)
    {
        RuleFor(x => x.Id)
            .GreaterThan(0)
            .WithMessage("Id must be greater than 0.")
            .MustAsync(async (id, cancellation) =>
            {
                return await bookingRepository.IsActiveBookingsAsync(id, cancellation);
            })
            .WithMessage($"Booking ID is Invaild  or already canceled.");

    }
}
