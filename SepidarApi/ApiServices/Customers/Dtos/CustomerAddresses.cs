namespace Honamic.SepidarApi.Services.Customers.Dtos;
public class CustomerAddresses
{
    [System.Text.Json.Serialization.JsonPropertyName("CustomerAddressID")]
    public int CustomerAddressID { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("Title")]
    public string Title { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("IsMain")]
    public bool IsMain { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("CityRef")]
    [System.ComponentModel.DataAnnotations.Range(1, int.MaxValue)]
    public int? CityRef { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("Address")]
    public string Address { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("ZipCode")]
    public string ZipCode { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("Latitude")]
    public double? Latitude { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("Longitude")]
    public double? Longitude { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("GUID")]
    public Guid? GUID { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("PathRef")]
    public int? PathRef { get; set; }

    private IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }
}
