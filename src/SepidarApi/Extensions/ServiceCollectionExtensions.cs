using Honamic.SepidarApi.ApiServices.Devices;
using Honamic.SepidarApi.ApiServices.Quotations;
using Honamic.SepidarApi.ApiServices.Stocks;
using Honamic.SepidarApi.HttpClients;
using Honamic.SepidarApi.Options;
using Honamic.SepidarApi.Services.Customers;
using Honamic.SepidarApi.Services.Items;
using Honamic.SepidarApi.Services.Users;
using Honamic.SepidarApi.Tokens;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Honamic.SepidarApi.Extensions;
public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSepidarApiServices(this IServiceCollection services)
    {
        AddHttpServices(services);

        services.AddTransient<DeviceApiService>();
        services.AddTransient<UserApiService>();
        services.AddTransient<ItemApiService>();
        services.AddTransient<UnitApiService>();
        services.AddTransient<CustomerApiService>();
        services.AddTransient<GeneralApiService>();
        services.AddTransient<QuotationApiService>();
        services.AddTransient<StockApiService>();

        return services;
    }

    private static void AddHttpServices(IServiceCollection services)
    {
        services.AddTransient<HttpInterceptorService>();
        services.AddTransient<IBearerTokensStore, InMemoryBearerTokensStore>();
        services.AddHttpClient(
                SepidarHttpClientFactory.httpClientName,
               (sp, client) =>
               {
                   var sepidarOptions = sp.GetRequiredService<IOptionsMonitor<SepidarApiOptions>>();
                   client.BaseAddress = new Uri(sepidarOptions.CurrentValue.BaseUrl);
                   client.DefaultRequestHeaders.Add("User-Agent", $"Honamic.SepidarApi.Client v{typeof(ServiceCollectionExtensions).Assembly.GetName().Version}");
                   client.Timeout = TimeSpan.FromSeconds(sepidarOptions.CurrentValue.Timeout);
               }
            )
            .AddHttpMessageHandler<HttpInterceptorService>();
        services.AddSingleton<SepidarHttpClientFactory>();
    }
}
