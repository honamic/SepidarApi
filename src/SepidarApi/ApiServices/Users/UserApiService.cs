using Honamic.SepidarApi.ApiServices;
using Honamic.SepidarApi.Helper;
using Honamic.SepidarApi.HttpClients;
using Honamic.SepidarApi.Services.Users.Dtos;
using Honamic.SepidarApi.Tokens;

namespace Honamic.SepidarApi.Services.Users;

public class UserApiService : ApiServiceBase
{
    const string LoginPath = "/api/users/login";
    private readonly IBearerTokensStore BearerTokensStore;
    private readonly SepidarHttpClientFactory HttpClientFactory;

    public UserApiService(SepidarHttpClientFactory httpClientFactory, IBearerTokensStore bearerTokensStore)
    {
        BearerTokensStore = bearerTokensStore;
        HttpClientFactory = httpClientFactory;

    }

    public async Task<LoginResponse> Login(string username, string password)
    {
        var data = new LoginRequest
        {
            UserName = username,
            PasswordHash = CryptoHelper.CreateMD5(password),
        };

        using var client = HttpClientFactory.CreateClient();

        var loginResponse = await PostAsync<LoginRequest, LoginResponse>(client, LoginPath, data);

        await BearerTokensStore.StoreToken(loginResponse.Token);

        return loginResponse;
    }
}