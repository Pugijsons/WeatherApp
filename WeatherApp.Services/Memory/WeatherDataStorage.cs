using System.Security.Cryptography.X509Certificates;
using WeatherApp.Core.Models;

namespace WeatherApp.Services.Memory;

public class WeatherDataStorage : IWeatherDataStorage
{
    private Dictionary<string, WeatherData> _weatherData;

    public WeatherDataStorage()
    {
        _weatherData = new Dictionary<string, WeatherData>();
    }
    public void AddDataEntry(string ip, WeatherData data)
    {
        _weatherData.Add(ip, data);
    }

    public WeatherData RetrieveData(string ip)
    {
        DeleteOldEntries();
        return _weatherData.GetValueOrDefault(ip);
    }

    public void DeleteOldEntries()
    {
        List<String> EntriesToRemove = _weatherData.Where(x => x.Value.current_weather.time.Hour != DateTime.Now.Hour).Select(x => x.Key).ToList();
        foreach(string str in EntriesToRemove)
        {
            _weatherData.Remove(str);
        }
    }
}