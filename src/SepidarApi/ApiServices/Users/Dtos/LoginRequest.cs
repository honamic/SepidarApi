namespace Honamic.SepidarApi.Services.Users.Dtos;

public class LoginRequest
{
    public string UserName { get; set; }
    public string PasswordHash { get; set; }
}
