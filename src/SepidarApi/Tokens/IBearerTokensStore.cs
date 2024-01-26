namespace Honamic.SepidarApi.Tokens;

public interface IBearerTokensStore
{
    Task<string?> GetBearerTokenAsync();
    Task StoreToken(string token);
    Task RemoveToken();
}
