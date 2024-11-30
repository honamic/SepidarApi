using Honamic.SepidarApi.ApiServices;
using Honamic.SepidarApi.ApiServices.SaleTypes.Dtos;
using Honamic.SepidarApi.HttpClients;

namespace Honamic.SepidarApi.Services.Items;

public class SaleTypeApiService : ApiServiceBase
{
    const string ItemsPath = "/api/SaleTypes";

    private readonly SepidarHttpClientFactory HttpClientFactory;

    public SaleTypeApiService(SepidarHttpClientFactory httpClientFactory)
    {
        HttpClientFactory = httpClientFactory;
    }

    public async Task<ICollection<SaleTypeResult>> GetSaleTypes()
    {
        using var client = HttpClientFactory.CreateClient();

        return await GetAsync<ICollection<SaleTypeResult>>(client, ItemsPath);
    }
}