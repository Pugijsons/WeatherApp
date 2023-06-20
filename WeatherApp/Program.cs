using Microsoft.EntityFrameworkCore;
using WeatherApp.Core;
using WeatherApp.Core.Models;
using WeatherApp.Data;
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
builder.Services.AddScoped<IEntityService<IPCallResponseModel>, EntityService<IPCallResponseModel>>();
builder.Services.AddScoped<IEntityService<WeatherData>, EntityService<WeatherData>>();
builder.Services.AddSingleton<IWeatherDataStorage, WeatherDataStorage>();
builder.Services.AddDbContext<WeatherAppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddTransient<IWeatherAppDbContext, WeatherAppDbContext>();

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
