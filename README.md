# SepidarApi
<p align="left">
  <a href="https://github.com/honamic/SepidarApi">
     <img alt="GitHub Actions status" src="https://github.com/honamic/SepidarApi/actions/workflows/build.yml/badge.svg">
    
  </a>
  <a href="https://www.nuget.org/packages/Honamic.SepidarApi/">
       <img alt="nuget" src="https://img.shields.io/nuget/v/Honamic.sepidarApi?style=plastic">
  </a>
</p>

Http Client for Sepidar e-commerce web service


Install via NuGet
-----------------

To install Honamic.SepidarApi, run the following command in the Package Manager Console:

```
PM> Install-Package Honamic.SepidarApi
```
Sepidar Documents
-----------------
  <a href="https://www.sepidarsystem.com/dl/sepidar-e-commerce-web-service-v1.0.0.pdf">
      sepidar-e-commerce-web-service-v1.0.0.pdf
  </a>
  <br/>
  <a href="https://www.sepidarsystem.com/api/sepidar/">
      Sepidar Swagger
  </a>
<br/>

## Usage

```csharp
         services.PostConfigure<SepidarApiOptions>(options =>
        {
            options.GenerationVersion = "110";
            options.RegistrationCode = "1000d6fa";
            options.Username = "username";
            options.Password = "password";
            options.PublicKey = null;
            options.BaseUrl = "http://127.0.0.1:7373";
            options.Timeout = 100;
            options.AutoLogin = true;
        });

        services.AddSepidarApiServices();
        services.AddTransient<TestService>();

```
```csharp
public class TestService 
{
    private readonly ILogger<TestService> _logger;
    private readonly IOptionsMonitor<SepidarApiOptions> options;
    private readonly UserApiService userService;
    private readonly ItemApiService itemService;
    private readonly CustomerApiService customerService;

    public TestService(ILogger<TestService> logger,
        IOptionsMonitor<SepidarApiOptions> sepidarOptions,
        UserApiService userService,
        ItemApiService itemService,
        CustomerApiService customerService)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        this.options = sepidarOptions;
        this.userService = userService;
        this.itemService = itemService;
        this.customerService = customerService;
    }

    public async void Run()
    {
        if (options.CurrentValue.AutoLogin)
        {
            _logger.LogWarning("Auto login is enabled");
        }
        else
        {
            var loginResult = await userService.Login(options.CurrentValue.Username, options.CurrentValue.Password);
            _logger.LogWarning($"login as {loginResult}");
        }

        var customers = await customerService.GetCustomers();      
    }
}
```
