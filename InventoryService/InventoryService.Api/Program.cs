using InventoryService.Infrastructure;
using InventoryService.Infrastructure.Interfaces;
using InventoryService.Application.Interfaces;
using InventoryService.Api.Services;
using Microsoft.EntityFrameworkCore;
using InventoryService.Application.Services;
using InventoryService.Infrastructure.Repositories;
var builder = WebApplication.CreateBuilder(args);

// gRPC
builder.Services.AddGrpc();

// EF Core In-Memory
builder.Services.AddDbContext<InventoryDbContext>(options =>
    options.UseInMemoryDatabase("InventoryDb"));

// Repositories & Services
builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();
builder.Services.AddScoped<IInventoryService, InventoryService.Application.Services.InventoryService>();
builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddScoped<IMemberService, MemberService>();
// AutoMapper

builder.Services.AddAutoMapper(
    typeof(InventoryService.Application.Mapping.MappingProfile),
    typeof(InventoryService.Api.Mapping.MappingDTO)
);


// Handler
builder.Services.AddScoped<InventoryServiceHandler>();

var app = builder.Build();

// gRPC Endpoints
app.MapGrpcService<InventoryServiceHandler>();
app.MapGet("/", () => "Inventory gRPC Service Running!");

app.Run();
