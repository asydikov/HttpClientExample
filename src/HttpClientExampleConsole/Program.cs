// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HttpClientExampleConsole;

internal static class Program
{
    public static void Main(string[] args)
    {
        // Generic host
        var hostApplicationBuilder = Host.CreateApplicationBuilder(args);

        // Named HttpClient instances
        hostApplicationBuilder.Services.AddHttpClient(Constants.HttpClientName,
            config => { config.BaseAddress = new Uri("https://swapi.dev/"); });
        hostApplicationBuilder.Services.AddSingleton<IMedium, HttpMedium>();
        hostApplicationBuilder.Services.AddSingleton<IMonitor, Monitor>();

        hostApplicationBuilder.Services.AddLogging(x => x.SetMinimumLevel(LogLevel.None));
        
        hostApplicationBuilder.Build()
            .Services.GetService<IMonitor>()!
            .StartAsync(CancellationToken.None)
            .Wait();
    }
}