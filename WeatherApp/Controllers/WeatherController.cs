using Microsoft.AspNetCore.Mvc;
using WeatherApp.Core;
using WeatherApp.Core.Models;

namespace WeatherApp.Controllers
{
    [ApiController]
    [Route("")]
    public class WeatherController : ControllerBase
    {
        private readonly ILocationService _locationService;
        private readonly IWeatherService _weatherService;

        public WeatherController(ILocationService locationService, IWeatherService weatherService)
        {
            _locationService = locationService;
            _weatherService = weatherService;
        }

        /*[HttpGet]
        public async Task<IActionResult> GetLocationData()
        {
            var locationData = await _locationService.GetLocationData();
            return Ok(locationData);
        }*/

        [HttpGet]
        public async Task<IActionResult> GetWeatherData()
        {
            var weatherData = await _weatherService.GetWeatherData();
            return Ok(weatherData);
        }
    }
}
