using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace OpenWeatherMapApiClient
{
    class AuthenticatedHttpClientHandler : HttpClientHandler
    {
        private readonly Func<Task<string>> _getApiKey;

        public AuthenticatedHttpClientHandler(Func<Task<string>> getApiKey)
        {
            _getApiKey = getApiKey ?? throw new ArgumentNullException(nameof(getApiKey));
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // See if the request has an authorize header
            var uriBuilder = new UriBuilder(request.RequestUri);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query["appid"] = await _getApiKey();

            uriBuilder.Query = query.ToString();

            request.RequestUri = uriBuilder.Uri;

            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}
