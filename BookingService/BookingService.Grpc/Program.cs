using BookingService.Infrastructure;
using BookingService.Infrastructure.Services;
using BookingService.Application.Clients;
using MediatR;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using BookingService.Grpc.Services;
using BookingService.Application.Validators;
using System.Reflection;
using BookingService.Application.Interfaces;
using BookingService.Infrastructure.Repositories;
using FluentValidation;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddDbContext<BookingDbContext>(options =>
            options.UseInMemoryDatabase("BookingDb"));

        services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
        services.AddGrpc();
        services.AddFluentValidationAutoValidation()
                .AddValidatorsFromAssemblyContaining<CreateBookingCommandValidator>();

        services.AddScoped<IBookingRepository, BookingRepository>();
    })
    .ConfigureWebHostDefaults(webBuilder =>
    {
        webBuilder.Configure(app =>
        {
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<BookingGrpcService>();
            });
        });
    })
    .Build();

host.Run();
