using System.Text.Json;
using WeatherApp.Core;
using WeatherApp.Core.Models;
using WeatherApp.Data;
using WeatherApp.Services.Memory;

namespace WeatherApp.Services;

public class WeatherService : IWeatherService
{
    private readonly ILocationService _locationService;
    private readonly IWeatherDataStorage _storage;
    private readonly WeatherDictionary _dictionary;
    private readonly HttpClient _client;
    private readonly IEntityService<WeatherData> _weatherDataEntityService;

    public WeatherService(ILocationService locationService, WeatherDictionary dictionary, IWeatherDataStorage storage, IEntityService<WeatherData> weatherDataEntityService)
    {
        _locationService = locationService;
        _dictionary = dictionary;
        _storage = storage;
        _client = new HttpClient();
        _weatherDataEntityService = weatherDataEntityService;
    }

    public async Task<CurrentWeatherModel> GetWeatherDataAsync()
    {
        var locationData = _locationService.GetLocationDataAsync();
        var retrievedData = _storage.RetrieveData(locationData.Result.query);

        if (retrievedData != null)
        {
            return retrievedData.current_weather;
        }

        var weatherData =
            await _client.GetAsync(
                $"https://api.open-meteo.com/v1/forecast?latitude={locationData.Result.lat}&longitude={locationData.Result.lon}&current_weather=true&temperature_2m,weathercode,windspeed_10m&timezone=auto");
        weatherData.EnsureSuccessStatusCode();
        string jsonResponse = await weatherData.Content.ReadAsStringAsync();
        var response = JsonSerializer.Deserialize<WeatherData>(jsonResponse);
        _storage.AddDataEntry(locationData.Result.query, response);
        _weatherDataEntityService.Add(response);

        return response.current_weather;
    }

    public ReturnDataModel CreateReturnData(CurrentWeatherModel model)
    {
        ReturnDataModel returnData = new ReturnDataModel();
        returnData.Temperature = model.temperature + " °C";
        returnData.Windspeed = model.windspeed + " km/h";
        returnData.Winddirection = model.winddirection + " degrees";
        returnData.Time = model.time.TimeOfDay.ToString();
        returnData.WeatherDescription = _dictionary.Weather[model.weathercode];
        
        if (model.is_day == 1)
        {
            returnData.IsDay = true;
        }

        else returnData.IsDay = false;
        return returnData;
    }
}
