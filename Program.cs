using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;

internal class Program
{
    private static void Main(string[] args)
    {
        var host = new HostBuilder()
        .ConfigureFunctionsWorkerDefaults()
        .ConfigureServices( s =>
        {
            s.AddSingleton<IHttpClientFactory, HttpClientFactory>()
        })
        .Build();

        host.Run();
    }
}