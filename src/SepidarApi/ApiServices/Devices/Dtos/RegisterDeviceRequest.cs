namespace Honamic.SepidarApi.ApiServices.Devices.Dtos;

public class RegisterDeviceRequest
{
    public string Cypher { get; set; }
    public string IV { get; set; }
    public string IntegrationID { get; set; }
}
