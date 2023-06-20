using WeatherApp.Core.Models;

namespace WeatherApp.Core;

public interface IWeatherService
{
    public Task<CurrentWeatherModel> GetWeatherDataAsync();
}