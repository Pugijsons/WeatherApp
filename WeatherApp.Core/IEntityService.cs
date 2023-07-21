namespace WeatherApp.Core;

public interface IEntityService<T> where T : class
{
    void Add(T entity);
}