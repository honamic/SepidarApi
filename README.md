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
```
