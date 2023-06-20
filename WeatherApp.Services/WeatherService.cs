using System.Text.Json;
using WeatherApp.Core;
using WeatherApp.Core.Models;

namespace WeatherApp.Services;

public class WeatherService : IWeatherService
{
    private readonly ILocationService _locationService;
    public WeatherService(ILocationService locationService)
    {
        _locationService = locationService;
    }

    public async Task<CurrentWeatherModel> GetWeatherDataAsync()
    {
        var locationData = _locationService.GetLocationDataAsync();
        using var client = new HttpClient();
        var weatherData =
            await client.GetAsync(
                $"https://api.open-meteo.com/v1/forecast?latitude={locationData.Result.lat}&longitude={locationData.Result.lon}&current_weather=true&temperature_2m,weathercode,windspeed_10m&timezone=auto");
        weatherData.EnsureSuccessStatusCode();
        string jsonResponse = await weatherData.Content.ReadAsStringAsync();
        var response = JsonSerializer.Deserialize<WeatherData>(jsonResponse);
        return response.current_weather;
    }
}
