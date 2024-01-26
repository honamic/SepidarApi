using Honamic.SepidarApi.ApiServices;
using Honamic.SepidarApi.ApiServices.Items.Dtos;
using Honamic.SepidarApi.HttpClients;
using Honamic.SepidarApi.Services.Items.Dtos;

namespace Honamic.SepidarApi.Services.Items;

public class ItemApiService : ApiServiceBase
{
    const string ItemsPath = "/api/items";
    const string InventoriesPath = "/api/Items/Inventories";
    const string InventoriesQuantityPath = "/api/Items/Inventories/Quantity";

    private readonly SepidarHttpClientFactory HttpClientFactory;

    public ItemApiService(SepidarHttpClientFactory httpClientFactory)
    {
        HttpClientFactory = httpClientFactory;
    }

    public async Task<IEnumerable<ItemResult>> GetItems()
    {
        using var client = HttpClientFactory.CreateClient();

        return await GetAsync<IEnumerable<ItemResult>>(client, ItemsPath);
    }

    public async Task<ItemResult> GetItem(int id)
    {
        using var client = HttpClientFactory.CreateClient();

        return await GetAsync<ItemResult>(client, $"{ItemsPath}/{id}");
    } 

    public async Task<IEnumerable<InventoryResult>> GetInventory(int id)
    {
        using var client = HttpClientFactory.CreateClient();

        return await GetAsync< IEnumerable<InventoryResult>>(client, $"{InventoriesPath}/{id}");
    }

    public async Task<IEnumerable<InventoryResult>> GetInventories()
    {
        using var client = HttpClientFactory.CreateClient();

        return await GetAsync<IEnumerable<InventoryResult>>(client, $"{InventoriesPath}");
    }

    public async Task<IEnumerable<InventoryQuantityResult>> GetQuantity(int id)
    {
        using var client = HttpClientFactory.CreateClient();

        return await GetAsync<IEnumerable<InventoryQuantityResult>>(client, $"{InventoriesQuantityPath}/{id}");
    }

}
