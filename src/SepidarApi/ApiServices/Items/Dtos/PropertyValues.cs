namespace Honamic.SepidarApi.Services.Items.Dtos;

public partial class PropertyValues
{

    [System.Text.Json.Serialization.JsonPropertyName("PropertyRef")]
    [System.ComponentModel.DataAnnotations.Range(1, int.MaxValue)]
    public int PropertyRef { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("Value")]
    public string Value { get; set; }

    private IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}