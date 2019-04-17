using Newtonsoft.Json;

namespace OpenWeatherMapApiClient.Models.Common
{
    public class Precipitation
    {
        [JsonProperty("3h")]
        public float Intensity { get; set; }
    }
}
