using System.Net;

namespace HttpClientExampleConsole;

public interface IMedium
{
    Task<HttpStatusCode> Check(CancellationToken cancellationToken);
    Task<HttpStatusCode> CheckWithHttpClientFactory(CancellationToken cancellationToken);
}