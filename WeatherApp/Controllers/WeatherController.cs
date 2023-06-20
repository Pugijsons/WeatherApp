using Microsoft.AspNetCore.Mvc;
using WeatherApp.Core;
using WeatherApp.Core.Models;

namespace WeatherApp.Controllers
{
    [ApiController]
    [Route("")]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService _weatherService;
        private readonly ILocationService _locationService;

        public WeatherController(ILocationService locationService, IWeatherService weatherService)
        {
            _weatherService = weatherService;
            _locationService = locationService;
        }

        [HttpGet]
        [Route("location")]
        public async Task<IActionResult> GetLocationData()
        {
            var locationData = await _locationService.GetLocationDataAsync();
            return Ok(locationData);
        }

        [HttpGet]
        [Route("weather")]
        public async Task<IActionResult> GetWeatherData()
        {
            var weatherData = await _weatherService.GetWeatherDataAsync();
            return Ok(weatherData);
        }
    }
}
