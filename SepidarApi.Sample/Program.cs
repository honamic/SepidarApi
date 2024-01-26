using Honamic.SepidarApi.Extensions;
using Honamic.SepidarApi.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

class Program
{
    static async Task Main(string[] args)
    {
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);
        var serviceProvider = serviceCollection.BuildServiceProvider();
        var testService = serviceProvider.GetRequiredService<ITestService>();

        testService.Run();

        Console.ReadKey();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddLogging(configure => configure.AddConsole().AddDebug());
        services.AddTransient<ITestService, TestService>();

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
    }
}