using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using Microsoft.Extensions.Logging;

internal class Program
{
    private static void Main(string[] args)
    {
        var logger = LoggerFactory.Create(config =>
        {
            config.AddConsole();
        }).CreateLogger("Program");

        logger.LogInformation("========================HELLO========================");

        var host = new HostBuilder()
        .ConfigureFunctionsWorkerDefaults()
        .ConfigureServices( s =>
        {
            s.AddSingleton<IHttpClientFactory, HttpClientFactory>();
        })
        .Build();

        host.Run();
    }
}