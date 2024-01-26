using Honamic.SepidarApi.HttpClients;
using Honamic.SepidarApi.ApiServices.Quotations.Dtos;
using System.Globalization;

namespace Honamic.SepidarApi.ApiServices.Quotations;

public class QuotationApiService : ApiServiceBase
{
    const string QuotationsPath = "/api/quotations";

    private readonly SepidarHttpClientFactory HttpClientFactory;

    public QuotationApiService(SepidarHttpClientFactory httpClientFactory)
    {
        HttpClientFactory = httpClientFactory;
    }

    public async Task<IEnumerable<QuotationResult>> GetAll(DateTimeOffset? fromDate, DateTimeOffset? toDate)
    {
        using var client = HttpClientFactory.CreateClient();

        var path = QuotationsPath + "?";

        if (fromDate != null)
        {
            path += $"fromDate={Uri.EscapeDataString(fromDate.Value.Date.ToString("s", CultureInfo.InvariantCulture))}&";
        }

        if (toDate != null)
        {
            path += $"toDate={Uri.EscapeDataString(toDate.Value.ToString("s", CultureInfo.InvariantCulture))}&";
        }

        return await GetAsync<IEnumerable<QuotationResult>>(client, path);
    }

    public Task<IEnumerable<QuotationResult>> GetAll()
    {
        return GetAll(null, null);
    }

    public async Task<QuotationResult> Get(int id)
    {
        using var client = HttpClientFactory.CreateClient();

        return await GetAsync<QuotationResult>(client, $"{QuotationsPath}/{id}");
    }


    public async Task<QuotationResult> Post(NewQuotationDto newQuotation)
    {
        using var client = HttpClientFactory.CreateClient();

        return await PostAsync<NewQuotationDto, QuotationResult>(client, QuotationsPath, newQuotation);
    }

    public async Task Close(int id)
    {
        using var client = HttpClientFactory.CreateClient();

        await client.PostAsync($"{QuotationsPath}/{id}/Close/", null);
    }

    public async Task UnClose(int id)
    {
        using var client = HttpClientFactory.CreateClient();

        await client.PostAsync($"{QuotationsPath}/{id}/UnClose/", null);
    }

    public async Task Delete(int id)
    {
        using var client = HttpClientFactory.CreateClient();

        await client.DeleteAsync($"{QuotationsPath}/{id}");
    }
}
