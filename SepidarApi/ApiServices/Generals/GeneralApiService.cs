using Honamic.SepidarApi.ApiServices;
using Honamic.SepidarApi.ApiServices.Units.Dtos;
using Honamic.SepidarApi.HttpClients;

namespace Honamic.SepidarApi.Services.Items;

public class GeneralApiService : ApiServiceBase
{
    const string GenerationVersionPath = "/api/General/GenerationVersion";
    const string SettingsPath = "/api/General/Settings";
    const string CorporationPath = "/api/General/Corporation";


    private readonly SepidarHttpClientFactory HttpClientFactory;

    public GeneralApiService(SepidarHttpClientFactory httpClientFactory)
    {
        HttpClientFactory = httpClientFactory;
    }

    public async Task<GeneralResult> GetGenerationVersion()
    {
        using var client = HttpClientFactory.CreateClient();

        return await GetAsync<GeneralResult>(client, GenerationVersionPath);
    }
    public async Task<SettingsResut> GetSettings()
    {
        using var client = HttpClientFactory.CreateClient();

        return await GetAsync<SettingsResut>(client, SettingsPath);
    }

}
