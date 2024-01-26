using Honamic.SepidarApi.ApiServices;
using Honamic.SepidarApi.ApiServices.Units.Dtos;
using Honamic.SepidarApi.HttpClients;

namespace Honamic.SepidarApi.Services.Items;

public class UnitApiService : ApiServiceBase
{
    const string ItemsPath = "/api/Units";

    private readonly SepidarHttpClientFactory HttpClientFactory;

    public UnitApiService(SepidarHttpClientFactory httpClientFactory)
    {
        HttpClientFactory = httpClientFactory;
    }

    public async Task<ICollection<UnitResult>> GetUnits()
    {
        using var client = HttpClientFactory.CreateClient();

        return await GetAsync<ICollection<UnitResult>>(client, ItemsPath);
    }

}
