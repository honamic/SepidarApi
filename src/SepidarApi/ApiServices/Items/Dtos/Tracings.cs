namespace Honamic.SepidarApi.Services.Items.Dtos;

public partial class Tracings
{

    [System.Text.Json.Serialization.JsonPropertyName("TracingID")]
    [System.ComponentModel.DataAnnotations.Range(1, int.MaxValue)]
    public int TracingID { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("IsSelectable")]
    public bool IsSelectable { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("Title")]
    public string Title { get; set; }

    private IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}