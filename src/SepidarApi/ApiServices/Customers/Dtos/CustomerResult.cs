namespace Honamic.SepidarApi.Services.Customers.Dtos;
public class CustomerResult
{
    [System.Text.Json.Serialization.JsonPropertyName("AccountingRemainder")]
    public double? AccountingRemainder { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("RemainderWithoutCheque")]
    public double? RemainderWithoutCheque { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("CreditRemainder")]
    public double? CreditRemainder { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("CustomerID")]
    [System.ComponentModel.DataAnnotations.Range(1, int.MaxValue)]
    public int CustomerID { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("GUID")]
    public Guid? GUID { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("Title")]
    public string Title { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("Code")]
    public string Code { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("PhoneNumber")]
    public string PhoneNumber { get; set; }


    [System.Text.Json.Serialization.JsonPropertyName("CustomerType")]
    public CustomerType CustomerType { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("Name")]
    public string Name { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("LastName")]
    public string LastName { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("BirthDate")]
    public DateTimeOffset? BirthDate { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("NationalID")]
    public string NationalID { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("EconomicCode")]
    public string EconomicCode { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("Version")]
    [System.ComponentModel.DataAnnotations.Range(1, int.MaxValue)]
    public int Version { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("GroupingRef")]
    [System.ComponentModel.DataAnnotations.Range(1, int.MaxValue)]
    public int? GroupingRef { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("DiscountRate")]
    public double DiscountRate { get; set; }

    public string? MainAddress => GetMainAddress();

    [System.Text.Json.Serialization.JsonPropertyName("Addresses")]
    public ICollection<CustomerAddresses> Addresses { get; set; }

    private IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }


    public override string ToString()
    {
        return $"{CustomerID}-{Code}-{Title}";
    }

    private string? GetMainAddress()
    {
        if (Addresses is null)
            return string.Empty;

        return Addresses
              .Where(c => c.IsMain == true)
              .Select(c => c.Address)
              .FirstOrDefault();

    }

}