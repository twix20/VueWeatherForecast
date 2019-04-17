using System;

namespace WeatherForecast.Application.ViewModels
{
    public class ForecastDayViewModel
    {
        public DateTime Date { get; set; }
        public double? AverageTemperature { get; set; }
        public long? Humidity { get; set; }
        public double? WindSpeed { get; set; }
    }
}
