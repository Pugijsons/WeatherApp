using WeatherApp.Core;
using WeatherApp.Data;

namespace WeatherApp.Services;

public class EntityService<T> : IEntityService<T> where T : class
{
    private readonly IWeatherAppDbContext _context;

    public EntityService(IWeatherAppDbContext context)
    {
        _context = context;
    }

    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
        _context.SaveChanges();
    }
}