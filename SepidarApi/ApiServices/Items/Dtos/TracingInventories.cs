namespace Honamic.SepidarApi.Services.Items.Dtos;

public partial class TracingInventories
{

    [System.Text.Json.Serialization.JsonPropertyName("TracingRef")]
    [System.ComponentModel.DataAnnotations.Range(1, int.MaxValue)]
    public int TracingRef { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("Inventory")]
    public double Inventory { get; set; }

    private IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}