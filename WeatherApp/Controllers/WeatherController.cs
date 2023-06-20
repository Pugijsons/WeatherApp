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

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet]
        public async Task<IActionResult> GetWeatherData()
        {
            var weatherData = await _weatherService.GetWeatherData();
            return Ok(weatherData);
        }
    }
}
