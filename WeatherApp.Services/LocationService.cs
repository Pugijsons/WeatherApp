using WeatherApp.Core;
using WeatherApp.Core.Models;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace WeatherApp.Services
{
    public class LocationService : ILocationService
    {
        public async Task<IPQuery> GetLocationData()
        {
            using var client = new HttpClient();
            var IPQueryData = await client.GetAsync("http://ip-api.com/json/?fields=lat,lon,query");
            IPQueryData.EnsureSuccessStatusCode();
            string jsonResponse = await IPQueryData.Content.ReadAsStringAsync();
            var response = JsonSerializer.Deserialize<IPCallResponseModel>(jsonResponse);
            IPQuery returnQuery = new IPQuery(null, response.query, response.lat, response.lon);
            return returnQuery;
        }
    }
}