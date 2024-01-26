using System.Net.Http.Json;
using System.Text.Json;

namespace Honamic.SepidarApi.ApiServices;

public abstract class ApiServiceBase
{
    public static T GetResponseObject<T>(string jsonContent)
     where T : class
    {
        return JsonSerializer.Deserialize<T>(jsonContent);
    }

    public static async Task<TResponse> PostAsync<TRequest, TResponse>(HttpClient client, string url, TRequest data)
        where TResponse : class
    {
        var response = await client.PostAsJsonAsync(url, data);
        var jsonContent = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            var error = GetResponseObject<ErrorResponse>(jsonContent);
            throw new Exception(error?.Message ?? string.Empty);
        }

        var registerResponse = GetResponseObject<TResponse>(jsonContent);
        return registerResponse;
    }

    public static async Task<TResponse> GetAsync<TResponse>(HttpClient client, string url)
        where TResponse : class
    {
        var response = await client.GetAsync(url);
        var jsonContent = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            var error = GetResponseObject<ErrorResponse>(jsonContent);
            throw new Exception(error?.Message ?? string.Empty);
        }

        var registerResponse = GetResponseObject<TResponse>(jsonContent);
        return registerResponse;
    }

}