using System.Collections.Generic;

namespace OpenWeatherMapApiClient.Models.Common
{
    public class Forecast
    {
        public string cod { get; set; }
        public float message { get; set; }
        public int cnt { get; set; }
        public IList<ForecastMeasurement> list { get; set; }
        public City city { get; set; }
    }

}
