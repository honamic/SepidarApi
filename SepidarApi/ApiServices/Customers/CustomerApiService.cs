using Honamic.SepidarApi.ApiServices;
using Honamic.SepidarApi.HttpClients;
using Honamic.SepidarApi.Services.Customers.Dtos;

namespace Honamic.SepidarApi.Services.Customers;
public class CustomerApiService : ApiServiceBase
{
    const string CustomersPath = "/api/customers";
    private readonly SepidarHttpClientFactory HttpClientFactory;

    public CustomerApiService(SepidarHttpClientFactory httpClientFactory)
    {
        HttpClientFactory = httpClientFactory;
    }

    public async Task<ICollection<CustomerResult>> GetCustomers()
    {
        using var client = HttpClientFactory.CreateClient();

        return await GetAsync<ICollection<CustomerResult>>(client, CustomersPath);
    }

    public async Task<CustomerResult> GetCustomer(int id)
    {
        using var client = HttpClientFactory.CreateClient();

        return await GetAsync<CustomerResult>(client, $"{CustomersPath}/{id}");
    }
}