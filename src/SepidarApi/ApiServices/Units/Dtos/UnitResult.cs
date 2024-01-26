namespace Honamic.SepidarApi.ApiServices.Units.Dtos;

public partial class UnitResult
{
    public override string ToString()
    {
        return $"{UnitID}-{Title}";
    }

    [System.Text.Json.Serialization.JsonPropertyName("UnitID")]
    public int UnitID { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("Title")]
    public string Title { get; set; }


}