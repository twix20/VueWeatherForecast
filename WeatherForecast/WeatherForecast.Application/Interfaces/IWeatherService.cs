using System.Threading.Tasks;
using WeatherForecast.Application.ViewModels;

namespace WeatherForecast.Application.Interfaces
{
    public interface IWeatherService
    {
        Task<ForecastViewModel> GetForecastByCityName(string cityName);

        Task<ForecastViewModel> GetForecastByZipCode(string zipCode);
    }
}
