using System.Net.Http;

public class HttpClientFactory : IHttpClientFactory
{
    private readonly IHttpClientFactory _httpClientFactory;

    public HttpClientFactory(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public HttpClient CreateClient(string name)
    {
        return _httpClientFactory.CreateClient(name);
    }
}