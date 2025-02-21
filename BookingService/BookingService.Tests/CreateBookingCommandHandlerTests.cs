using Microsoft.EntityFrameworkCore;
using BookingService.Infrastructure;
using BookingService.Application.Commands;
using BookingService.Application.Handlers;
using BookingService.Domain;
using BookingService.Application.Clients;
using BookingService.Application.Interfaces;
using BookingService.Infrastructure.Repositories;
using FluentValidation;
using Moq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace BookingService.Tests
{
    [TestClass]
    public class CreateBookingCommandHandlerTests
    {
        private BookingDbContext _dbContext;
        private IBookingRepository _bookingRepository;
        private FakeInventoryServiceClient _fakeInventoryClient;
        private CreateBookingCommandHandler _handler;

        private const int TestMemberId = 1;
        private const int TestInventoryItemId = 2;

        [TestInitialize]
        public void Setup()
        {
            SetupDatabase();
            SetupDependencies();
        }

        private void SetupDatabase()
        {
            var options = new DbContextOptionsBuilder<BookingDbContext>()
                .UseInMemoryDatabase(nameof(BookingDbContext))
                .Options;

            _dbContext = new BookingDbContext(options);
            _dbContext.Database.EnsureDeleted();
            _dbContext.Database.EnsureCreated();
        }

        private void SetupDependencies()
        {
            _bookingRepository = new BookingRepository(_dbContext);
            _fakeInventoryClient = new FakeInventoryServiceClient();

            var mockValidator = new Mock<IValidator<CreateBookingCommand>>();
            mockValidator.Setup(v => v.ValidateAsync(It.IsAny<CreateBookingCommand>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(new FluentValidation.Results.ValidationResult()); // No validation errors

            _handler = new CreateBookingCommandHandler(_bookingRepository, _fakeInventoryClient, mockValidator.Object);
        }

        [TestCleanup]
        public void TearDown()
        {
            _dbContext?.Dispose();
        }

        [TestMethod]
        public async Task Handle_ValidCommand_ShouldCreateBooking_AndDecrementInventory()
        {
            var command = new CreateBookingCommand { MemberId = TestMemberId, InventoryItemId = TestInventoryItemId };
            Booking booking = await _handler.Handle(command, CancellationToken.None);

            Assert.IsNotNull(booking);
            Assert.AreEqual(TestMemberId, booking.MemberId);
            Assert.AreEqual(TestInventoryItemId, booking.InventoryItemId);
            Assert.IsFalse(booking.IsCancelled);
            Assert.IsTrue(_fakeInventoryClient.DecrementCalled);
        }

        [TestMethod]
        public async Task Handle_InventoryDecrementFailure_ShouldThrowException()
        {
            _fakeInventoryClient.DecrementSucceeds = false;
            var command = new CreateBookingCommand { MemberId = TestMemberId, InventoryItemId = TestInventoryItemId };

            await Assert.ThrowsExceptionAsync<System.Exception>(async () => await _handler.Handle(command, CancellationToken.None));
        }

        [TestMethod]
        public async Task CancelBooking_ShouldMarkBookingAsCancelled()
        {
            var booking = await AddBookingToDatabase(TestMemberId, TestInventoryItemId);

            await _bookingRepository.CancelBookingAsync(booking.Id, CancellationToken.None);
            var cancelledBooking = await _dbContext.Bookings.FindAsync(booking.Id);

            Assert.IsNotNull(cancelledBooking);
            Assert.IsTrue(cancelledBooking.IsCancelled);
        }

        private async Task<Booking> AddBookingToDatabase(int memberId, int inventoryItemId)
        {
            var booking = new Booking
            {
                MemberId = memberId,
                InventoryItemId = inventoryItemId,
                BookingDateTime = System.DateTime.UtcNow,
                IsCancelled = false
            };

            await _dbContext.Bookings.AddAsync(booking);
            await _dbContext.SaveChangesAsync();
            return booking;
        }
    }

    public class FakeInventoryServiceClient : IInventoryServiceClient
    {
        public bool InventoryAvailable { get; set; } = true;
        public bool DecrementCalled { get; private set; } = false;
        public bool DecrementSucceeds { get; set; } = true;
        public bool IncrementSucceeds { get; set; } = true;

        public Task<bool> IsInventoryAvailableAsync(int inventoryItemId) => Task.FromResult(InventoryAvailable);

        public Task<bool> DecrementInventoryAsync(int inventoryItemId)
        {
            DecrementCalled = true;
            return Task.FromResult(DecrementSucceeds);
        }

        public Task<bool> IncreaseInventoryAsync(int inventoryItemId) => Task.FromResult(IncrementSucceeds);
    }
}
