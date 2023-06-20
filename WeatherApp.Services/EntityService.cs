using WeatherApp.Core;
using WeatherApp.Core.Models;
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

    public void Delete(T entity)
    {
        throw new NotImplementedException();
    }

    public T GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(T entity)
    {
        throw new NotImplementedException();
    }
}