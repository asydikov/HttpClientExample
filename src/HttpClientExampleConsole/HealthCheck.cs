using System.Net;

namespace HttpClientExampleConsole;

public class HealthCheck
{
    public async Task<HttpStatusCode> Request()
    {
        using var httpClient = new HttpClient();
        var httpResponseMessage = await httpClient.GetAsync(new Uri("https://swapi.dev/api/people/1"));
        return httpResponseMessage.StatusCode;
    }
}