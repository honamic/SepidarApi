namespace Honamic.SepidarApi.Options;

public class SepidarApiOptions
{
    public SepidarApiOptions()
    {
        GenerationVersion = "110";
        RegistrationCode = "1000aaaa";
        Username = "username";
        Password = "password";
        PublicKey = string.Empty;
        BaseUrl = "http://127.0.0.1:7373";
        Timeout = 20;
        AutoLogin = true;
    }

    public string GenerationVersion { get; set; }
    public string? PublicKey { get; set; }
    public string? IntegrationId => RegistrationCode?.Substring(0, 4);
    public string RegistrationCode { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string BaseUrl { get; set; }
    public int Timeout { get; set; }
    public bool AutoLogin { get; set; }
}