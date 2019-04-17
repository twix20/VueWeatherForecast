using System.Collections.Generic;

namespace OpenWeatherMapApiClient.Models.Common
{
    public class ForecastMeasurement
    {
        public int dt { get; set; }
        public Main main { get; set; }
        public IList<Weather> weather { get; set; }
        public Clouds clouds { get; set; }
        public Wind wind { get; set; }
        public Sys sys { get; set; }
        public string dt_txt { get; set; }
        public Precipitation rain { get; set; }
        public Precipitation snow { get; set; }
    }
}
