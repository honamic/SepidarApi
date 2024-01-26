namespace Honamic.SepidarApi.Tokens;

public class InMemoryBearerTokensStore : IBearerTokensStore
{
    private static string? Token;


    public Task<string?> GetBearerTokenAsync()
    {
        return Task.FromResult(Token);
    }

    public Task RemoveToken()
    {
        Token = null;

        return Task.CompletedTask;
    }

    public Task StoreToken(string token)
    {
        Token = token;

        return Task.CompletedTask;
    }
}