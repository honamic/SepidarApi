using Honamic.SepidarApi.Helper;
using Honamic.SepidarApi.Options;
using Honamic.SepidarApi.Services.Users.Dtos;
using Honamic.SepidarApi.Tokens;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace Honamic.SepidarApi.HttpClients;

public class HttpInterceptorService : DelegatingHandler
{
    private readonly IBearerTokensStore _bearerTokensStore;
    private readonly IOptionsMonitor<SepidarApiOptions> sepidarOptions;
    private readonly SepidarHttpClientFactory HttpClientFactory;
    private const string loginPath = "/api/users/login";
    public HttpInterceptorService(
        IBearerTokensStore bearerTokensStore,
        IOptionsMonitor<SepidarApiOptions> sepidarOptions,
        SepidarHttpClientFactory httpClientFactory)
    {
        _bearerTokensStore = bearerTokensStore ?? throw new ArgumentNullException(nameof(bearerTokensStore));
        this.sepidarOptions = sepidarOptions;
        HttpClientFactory = httpClientFactory;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        await AddAccessTokenToAllRequestsAsync(request);

        var response = await base.SendAsync(request, cancellationToken);

        if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
        {
            await _bearerTokensStore.RemoveToken();
        }

        return response;
    }

    private async Task AddAccessTokenToAllRequestsAsync(HttpRequestMessage request)
    {
        foreach (var item in CreateHeaders())
        {
            request.Headers.Add(item.Key, item.Value);
        }


        if (request.RequestUri?.AbsolutePath == loginPath)
        {
            return;
        }

        var token = await _bearerTokensStore.GetBearerTokenAsync();

        if (token == null && sepidarOptions.CurrentValue.AutoLogin)
        {
            token = await Login(sepidarOptions.CurrentValue.Username, sepidarOptions.CurrentValue.Password);
            await _bearerTokensStore.StoreToken(token);
        }

        request.Headers.Authorization =
            token is not null ? new AuthenticationHeaderValue("Bearer", token) : null;
    }

    public Dictionary<string, string> CreateHeaders()
    {
        if( sepidarOptions.CurrentValue.PublicKey is null)
        {
            throw new Exception("SepidarApiOptions.PublicKey is not defined.");
        }

        if (sepidarOptions.CurrentValue.IntegrationId is null)
        {
            throw new Exception("SepidarApiOptions.RegistrationCode is not defined.");
        }

        var guid = Guid.NewGuid();
        var headers = new Dictionary<string, string>
            {
                { "GenerationVersion", sepidarOptions.CurrentValue.GenerationVersion },
                { "IntegrationID", sepidarOptions.CurrentValue.IntegrationId },
                { "ArbitraryCode", guid.ToString() },
            };

        headers["EncArbitraryCode"] = CryptoHelper.RsaEncrypt(sepidarOptions.CurrentValue.PublicKey, guid.ToByteArray());

        return headers;
    }


    public async Task<string> Login(string username, string password)
    {
        var data = new LoginRequest
        {
            UserName = username,
            PasswordHash = CryptoHelper.CreateMD5(password),
        };

        using var client = HttpClientFactory.CreateClient();

        var response = await client.PostAsJsonAsync(loginPath, data);

        if (response.IsSuccessStatusCode)
        {
            var jsonContent = await response.Content.ReadAsStringAsync();
            var loginResponse = JsonSerializer.Deserialize<LoginResponse>(jsonContent);
            if (!string.IsNullOrEmpty(loginResponse?.Token))
            {
                await _bearerTokensStore.StoreToken(loginResponse.Token);
                return loginResponse.Token;
            }

        }

        throw new Exception("login failed.");
    }
}