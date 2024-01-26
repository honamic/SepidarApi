using Honamic.SepidarApi.ApiServices.Devices.Dtos;
using Honamic.SepidarApi.Helper;
using Honamic.SepidarApi.HttpClients;

namespace Honamic.SepidarApi.ApiServices.Devices;

public class DeviceApiService : ApiServiceBase
{
    const string DeviceRegisterPath = "/api/Devices/Register/";
    private readonly SepidarHttpClientFactory HttpClientFactory;

    public DeviceApiService(SepidarHttpClientFactory httpClientFactory)
    {
        HttpClientFactory = httpClientFactory;
    }

    public async Task<RegisterResult> Register(string registrationCode, string integrationId)
    {
        var encryptionKey = registrationCode + registrationCode;
        var encryptedData = CryptoHelper.AesEncrypt(encryptionKey, integrationId);

        var data = new RegisterDeviceRequest
        {
            Cypher = encryptedData.Cipher,
            IV = encryptedData.IV,
            IntegrationID = integrationId,
        };

        using var client = HttpClientFactory.CreateClient();

        var registerResponse = await PostAsync<RegisterDeviceRequest, RegisterDeviceResponse>(client, DeviceRegisterPath, data);
        var publicKey = CryptoHelper.AesDecrypt(encryptionKey, registerResponse.Cypher, registerResponse.IV);
        var DeviceName = registerResponse.DeviceTitle;

        return new RegisterResult(publicKey, DeviceName);
    }

    public class RegisterResult
    {
        public RegisterResult(string publicKey, string deviceName)
        {
            PublicKey = publicKey;
            DeviceName = deviceName;
        }

        public string PublicKey { get; set; }
        public string DeviceName { get; set; }
    }
}
