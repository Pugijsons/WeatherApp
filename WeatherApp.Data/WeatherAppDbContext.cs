using Microsoft.EntityFrameworkCore;
using WeatherApp.Core.Models;

namespace WeatherApp.Data
{
    public class WeatherAppDbContext : DbContext, IWeatherAppDbContext
    {
        public WeatherAppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<IPCallResponseModel> IpCallResponse { get; set; }
        public DbSet<WeatherData> WeatherData { get; set; }
    }
}