namespace Honamic.SepidarApi.ApiServices.SaleTypes.Dtos;

public partial class SaleTypeResult
{
    public override string ToString()
    {
        return $"{SaleTypeID}-{Title}";
    }

    [System.Text.Json.Serialization.JsonPropertyName("SaleTypeID")]
    public int SaleTypeID { get; set; }


    [System.Text.Json.Serialization.JsonPropertyName("Title")]
    public string Title { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("Market")]
    public int Market { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("IsAvailable")]
    public bool IsAvailable { get; set; }
}