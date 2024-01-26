namespace Honamic.SepidarApi.HttpClients;
public class SepidarHttpClientFactory
{
    private readonly IHttpClientFactory HttpClientFactory;
    public const string httpClientName = "SepidarApi";
    
    public SepidarHttpClientFactory(IHttpClientFactory httpClientFactory)
    {
        HttpClientFactory = httpClientFactory;
    }

    public HttpClient CreateClient()
    {
        return HttpClientFactory.CreateClient(httpClientName);
    }
}
