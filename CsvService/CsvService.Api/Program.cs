using CsvService.Api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Grpc.Net.Client;
using InventoryService.Protos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddGrpcClient<Inventory.InventoryClient>(options =>
{
    options.Address = new Uri("https://localhost:5001");
});

builder.Services.AddScoped<InventoryClientService>();
builder.Services.AddScoped<CsvParserService>();
builder.Services.AddScoped<CsvManager>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseRouting();


app.MapControllers();

app.Run();
