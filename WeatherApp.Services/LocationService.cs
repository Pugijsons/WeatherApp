using WeatherApp.Core;
using WeatherApp.Core.Models;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace WeatherApp.Services
{
    public class LocationService : ILocationService
    {
        public async Task<IPCallResponseModel> GetLocationDataAsync()
        {
            using var client = new HttpClient();
            var IPQueryData = await client.GetAsync("http://ip-api.com/json/?fields=lat,lon,query");
            IPQueryData.EnsureSuccessStatusCode();
            string jsonResponse = await IPQueryData.Content.ReadAsStringAsync();
            var response = JsonSerializer.Deserialize<IPCallResponseModel>(jsonResponse);
            return response;
        }
    }
}