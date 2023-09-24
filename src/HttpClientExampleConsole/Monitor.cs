using Microsoft.Extensions.Hosting;

namespace HttpClientExampleConsole;

public class Monitor(IMedium medium) : IMonitor
{
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        for (var i = 0; i < 20; i++)
        {
            var result = await medium.Check(cancellationToken);
            Console.WriteLine($"Http request {i} - {result}");
        }
    }
}

public interface IMonitor
{
    Task StartAsync(CancellationToken cancellationToken);
}