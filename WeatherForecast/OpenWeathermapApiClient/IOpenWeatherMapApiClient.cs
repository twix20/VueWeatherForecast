using System.Threading.Tasks;
using OpenWeatherMapApiClient.Models.Common;
using Refit;

namespace OpenWeatherMapApiClient
{
    public interface IOpenWeatherMapApiClient
    {
        [Get("/data/2.5/forecast?q={cityName}")]
        Task<Forecast> GetForecastByCityName(string cityName);

        [Get("/data/2.5/forecast?zip={zipCode}")]
        Task<Forecast> GetForecastByZipCode(string zipCode);
    }
}
