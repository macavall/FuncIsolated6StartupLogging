# httpscale

Example of using ILogger (_For App Insights_) in the `Program.cs` file on Function App Startup

``` C#
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
```
![image](https://github.com/macavall/FuncIsolated6StartupLogging/assets/43223084/16c7c743-5987-4e75-b393-cef172b05a49)
