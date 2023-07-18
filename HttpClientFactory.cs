using System.Net.Http;

public class HttpClientFactory : IHttpClientFactory
{
    private readonly IHttpClientFactory _httpClientFactory;
    public HttpClient client;

    public HttpClientFactory(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    HttpClient IHttpClientFactory.CreateClient(string name)
    {
        if (client == null)
        {
            client = _httpClientFactory.CreateClient(name);
        }

        return client;
    }
}