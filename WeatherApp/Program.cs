using WeatherApp.Core;
using WeatherApp.Core.Models;
using WeatherApp.Services;
using WeatherApp.Services.Memory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<IWeatherService, WeatherService>();
builder.Services.AddScoped<WeatherDictionary>();
builder.Services.AddSingleton<IWeatherDataStorage, WeatherDataStorage>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
