using Xunit.Abstractions;

namespace HttpClientExampleConsoleTests;

public class HealthCheck(ITestOutputHelper output)
{
    // [Fact]
    // public async Task Request_NewHttpClientPerRequest_AllocatesNewPortForEachCall()
    // {
    //     var http = new HttpClientExampleConsole.HttpMedium();
    //
    //     for (var i = 0; i < 100; i++)
    //     {
    //         var result = await http.Check();
    //         output.WriteLine($"Http request status code {result}");
    //     }
    //     
    //     
    // }
}