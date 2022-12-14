using Newtonsoft.Json;
using System.Net;
using System.Text;
using Xunit.Abstractions;

namespace GeoApi.WebApi.IntegrationTests.Helpers
{
    public class RequestHelper
    {
        private readonly ITestOutputHelper _output;

        public RequestHelper(ITestOutputHelper output)
        {
            _output = output;
        }

        public async Task<(HttpStatusCode statusCode, TResponse response)> PostRequestAsync<TRequest, TResponse>(HttpClient client, string requestPath, TRequest request)
        {
            return await SendRequestAsync<TRequest, TResponse>(HttpMethod.Post, client, requestPath, request);
        }

        private async Task<(HttpStatusCode statusCode, TResponse response)> SendRequestAsync<TRequest, TResponse>(HttpMethod httpMethod, HttpClient client, string requestPath, TRequest request)
        {
            using var requestContent = typeof(TRequest) == typeof(string)
                ? new StringContent(request as string, Encoding.UTF8, "application/json")
                : new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
            var requestMessage = new HttpRequestMessage(httpMethod, requestPath) { Content = requestContent };
            using var response = await client.SendAsync(requestMessage);
            _output.WriteLine("Request:{0}\nStatusCode:{1}", requestPath, response.StatusCode);
            var responseString = await response.Content.ReadAsStringAsync();
            _output.WriteLine("Response:\n{0}", responseString);
            return (response.StatusCode, JsonConvert.DeserializeObject<TResponse>(responseString));
        }
    }
}
