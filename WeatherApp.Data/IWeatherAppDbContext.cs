using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WeatherApp.Core.Models;

namespace WeatherApp.Data;

public interface IWeatherAppDbContext
{
    public DbSet<IPCallResponseModel> IpCallResponse { get; set; }
    public DbSet<WeatherData> WeatherData { get; set; }

    DbSet<T> Set<T>() where T : class;
    EntityEntry<T> Entry<T>(T entity) where T : class;
    public int SaveChanges();
}