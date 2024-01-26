namespace Honamic.SepidarApi.ApiServices.Devices.Dtos;

public class RegisterDeviceResponse
{
    public string Cypher { get; set; }
    public string IV { get; set; }
    public string DeviceTitle { get; set; }
}