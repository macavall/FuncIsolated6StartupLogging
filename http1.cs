using System;
using System.Net;
using System.Net.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace httpscale
{
    public class http1
    {
        private readonly ILogger _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public http1(ILoggerFactory loggerFactory, IHttpClientFactory httpClientFactory)
        {
            _logger = loggerFactory.CreateLogger<http1>();
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }

        [Function("http1")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");



            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString("Welcome to Azure Functions!");

            return response;
        }
    }
}
