using WeatherApp.Core.Models;

namespace WeatherApp.Services.Memory;

public interface IWeatherDataStorage
{
    public void AddDataEntry(string ip, WeatherData data);
    public WeatherData RetrieveData(string ip);
    public void DeleteOldEntries();
}