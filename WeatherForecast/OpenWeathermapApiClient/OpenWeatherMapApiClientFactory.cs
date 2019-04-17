using System;
using System.Net.Http;
using System.Threading.Tasks;
using Refit;

namespace OpenWeatherMapApiClient
{
    public class OpenWeatherMapApiClientFactory
    {
        public static IOpenWeatherMapApiClient Create(Uri url, Func<Task<string>> getApiKey, RefitSettings settings = null)
        {
            return RestService.For<IOpenWeatherMapApiClient>(new HttpClient(new AuthenticatedHttpClientHandler(getApiKey))
            {
                BaseAddress = url
            }, settings);
        }
    }
}
