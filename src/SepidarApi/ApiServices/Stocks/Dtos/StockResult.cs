namespace Honamic.SepidarApi.ApiServices.Stocks.Dtos;

public partial class StockResult
{
    public override string ToString()
    {
        return $"{StockID}-{Title}";
    }

    [System.Text.Json.Serialization.JsonPropertyName("StockID")]
    public int StockID { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("Title")]
    public string Title { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("IsActive")]
    public bool IsActive { get; set; }


}