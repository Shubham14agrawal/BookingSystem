using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using BookingService.Infrastructure;
using BookingService.Infrastructure.Services;
using BookingService.Application.Clients;
using MediatR;
using Microsoft.EntityFrameworkCore;
using BookingService.Application.Validators;
using BookingService.Application.Interfaces;
using BookingService.Infrastructure.Repositories;
using BookingService.Application.Commands;
using BookingService.Application.Handlers;
using BookingService.Domain;
using InventoryService.Protos;
var builder = WebApplication.CreateBuilder(args);

// Configure EF Core (InMemory for demo; switch to SQL Server in production)
builder.Services.AddDbContext<BookingDbContext>(options =>
    options.UseInMemoryDatabase("BookingDb"));

// Register MediatR services
builder.Services.AddMediatR(cfg => cfg.AsScoped(), typeof(Program).Assembly);
builder.Services.AddGrpcClient<Inventory.InventoryClient>(o =>
{
    o.Address = new Uri("https://localhost:5001"); // URL where InventoryService is running
});

// Disable ASP.NET automatic validation (we will handle validation via MediatR pipeline)
builder.Services.AddControllers();

// Register FluentValidation services
builder.Services.AddValidatorsFromAssemblyContaining<CreateBookingCommandValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CancelBookingCommandValidator>();
builder.Services.AddScoped<IRequestHandler<CreateBookingCommand, Booking>, CreateBookingCommandHandler>();
builder.Services.AddScoped<IRequestHandler<CancelBookingCommand, Booking>, CancelBookingCommandHandler>();

// Disable automatic model validation to prevent FluentValidation from running synchronously
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

// Register application services
builder.Services.AddScoped<IInventoryServiceClient, InventoryServiceClient>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();

// Add Swagger for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Ensure the database is created
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<BookingDbContext>();
    db.Database.EnsureCreated();
}

// Configure middleware for development environment
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Map controllers
app.MapControllers();

// Run the application
app.Run();
