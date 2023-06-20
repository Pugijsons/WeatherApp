namespace WeatherApp.Core;

public interface IEntityService<T> where T : class
{
    T GetById(int id);
    void Add(T entity);
    void Update(T entity);
    void Delete(T entity);
}