namespace Honamic.SepidarApi.ApiServices.Units.Dtos;

public partial class GeneralResult
{
    public override string ToString()
    {
        return $"{GenerationVersion}-{LockNumber}";
    }

    public int GenerationVersion { get; set; }

    public string LockNumber { get; set; }
}
