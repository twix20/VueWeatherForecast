using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherForecast.Application.Interfaces;
using WeatherForecast.Application.ViewModels;

namespace WeatherForecast.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet("[action]")]
        [ProducesResponseType(typeof(ForecastDayViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Forecast(string city, string zipCode)
        {
            if (!string.IsNullOrEmpty(city))
                return Ok(await _weatherService.GetForecastByCityName(city));

            if (!string.IsNullOrEmpty(zipCode))
                return Ok(await _weatherService.GetForecastByZipCode(zipCode));

            return BadRequest("Invalid parameters");
        }
    }
}