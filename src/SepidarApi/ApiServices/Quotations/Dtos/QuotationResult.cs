
namespace Honamic.SepidarApi.ApiServices.Quotations.Dtos;

public partial class QuotationResult
{
    public override string ToString()
    {
        return $"id:{ID} - Number:{Number} - Date:{Date.ToString("s")}";
    }


    [System.Text.Json.Serialization.JsonPropertyName("ID")]
    public int ID { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("GUID")]
    public System.Guid? GUID { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("Number")]
    public int Number { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("Date")]
    public System.DateTimeOffset Date { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("Closed")]
    public bool Closed { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("CurrencyRef")]
    [System.ComponentModel.DataAnnotations.Range(1, int.MaxValue)]
    public int CurrencyRef { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("CustomerRef")]
    [System.ComponentModel.DataAnnotations.Range(1, int.MaxValue)]
    public int CustomerRef { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("AddressRef")]
    [System.ComponentModel.DataAnnotations.Range(1, int.MaxValue)]
    public int? AddressRef { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("SaleTypeRef")]
    [System.ComponentModel.DataAnnotations.Range(1, int.MaxValue)]
    public int SaleTypeRef { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("Items")]
    public System.Collections.Generic.ICollection<QuotationItemResult> Items { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("DiscountOnCustomer")]
    public double DiscountOnCustomer { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("Price")]
    public double Price { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("Discount")]
    public double Discount { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("Tax")]
    public double Tax { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("Duty")]
    public double Duty { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("Addition")]
    public double Addition { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("NetPrice")]
    public double NetPrice { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("Description")]
    public string Description { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("ExpirationDate")]
    public System.DateTimeOffset ExpirationDate { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }



}
