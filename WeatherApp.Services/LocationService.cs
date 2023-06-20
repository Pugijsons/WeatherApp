using WeatherApp.Core;
using WeatherApp.Core.Models;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace WeatherApp.Services
{
    public class LocationService : ILocationService
    {
        private readonly HttpClient _client;
        private readonly IEntityService<IPCallResponseModel> _iPCallResponseModelEntityService;

        public LocationService(IEntityService<IPCallResponseModel> iPCallResponseModelEntityService)
        {
            _client = new HttpClient();
            _iPCallResponseModelEntityService = iPCallResponseModelEntityService;
        }

        public async Task<IPCallResponseModel> GetLocationDataAsync()
        {
            var IPQueryData = await _client.GetAsync("http://ip-api.com/json/?fields=lat,lon,query");
            IPQueryData.EnsureSuccessStatusCode();
            string jsonResponse = await IPQueryData.Content.ReadAsStringAsync();
            var response = JsonSerializer.Deserialize<IPCallResponseModel>(jsonResponse);
            _iPCallResponseModelEntityService.Add(response);
            return response;
        }
    }
}