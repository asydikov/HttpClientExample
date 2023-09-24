using System.Net;

namespace HttpClientExampleConsole;

public class HttpMedium(IHttpClientFactory httpClientFactory) : IMedium // primary constructor C#12
{
    public async Task<HttpStatusCode> Check(CancellationToken cancellationToken)
    {
       // return await CheckWithHttpClient(cancellationToken);
          return await CheckWithHttpClientFactory(cancellationToken);
    }

    #region new HttpClient for every call

    private async Task<HttpStatusCode> CheckWithHttpClient(CancellationToken cancellationToken)
    {
        using var httpClient = new HttpClient();
        var httpResponseMessage =
            await httpClient.GetAsync(new Uri($"https://swapi.dev/api/people/1"), cancellationToken);
        return httpResponseMessage.StatusCode;
    }

    #endregion


    #region Use IHttpClientFactory

    public async Task<HttpStatusCode> CheckWithHttpClientFactory(CancellationToken cancellationToken)
    {
        using var httpClient = httpClientFactory.CreateClient(Constants.HttpClientName);
        var httpResponseMessage = await httpClient.GetAsync("api/people/1", cancellationToken); // swapi.dev/api/people/1
        return httpResponseMessage.StatusCode;
    }

    #endregion
}