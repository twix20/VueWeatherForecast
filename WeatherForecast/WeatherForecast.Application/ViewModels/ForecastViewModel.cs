using System.Collections.Generic;

namespace WeatherForecast.Application.ViewModels
{
    public class ForecastViewModel
    {
        public IEnumerable<ForecastDayViewModel> Days { get; set; }
    }
}
