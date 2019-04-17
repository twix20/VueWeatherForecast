using OpenWeatherMapApiClient;
using System.Threading.Tasks;
using AutoMapper;
using OpenWeatherMapApiClient.Models.Common;
using WeatherForecast.Application.Interfaces;
using WeatherForecast.Application.ViewModels;

namespace WeatherForecast.Application.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IMapper _mapper;
        private readonly IOpenWeatherMapApiClient _openWeatherMapApi;

        public WeatherService(IMapper mapper, IOpenWeatherMapApiClient openWeatherMapApi)
        {
            _mapper = mapper;
            _openWeatherMapApi = openWeatherMapApi;
        }

        public async Task<ForecastViewModel> GetForecastByCityName(string cityName)
        {
            var forecast = await _openWeatherMapApi.GetForecastByCityName(cityName);

            return _mapper.Map<Forecast, ForecastViewModel>(forecast);
        }

        public async Task<ForecastViewModel> GetForecastByZipCode(string zipCode)
        {
            var forecast = await _openWeatherMapApi.GetForecastByZipCode(zipCode);

            return _mapper.Map<Forecast, ForecastViewModel>(forecast);
        }
    }
}
