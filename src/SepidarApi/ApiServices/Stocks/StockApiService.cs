using Honamic.SepidarApi.ApiServices.Stocks.Dtos;
using Honamic.SepidarApi.HttpClients;

namespace Honamic.SepidarApi.ApiServices.Stocks;

public class StockApiService : ApiServiceBase
{
    const string ItemsPath = "/api/Stocks";

    private readonly SepidarHttpClientFactory HttpClientFactory;

    public StockApiService(SepidarHttpClientFactory httpClientFactory)
    {
        HttpClientFactory = httpClientFactory;
    }

    public async Task<ICollection<StockResult>> GetStocks()
    {
        using var client = HttpClientFactory.CreateClient();

        return await GetAsync<ICollection<StockResult>>(client, ItemsPath);
    }
}