
namespace Honamic.SepidarApi.ApiServices.Quotations.Dtos;
public class NewQuotationDto
{
    public System.Guid? GUID { get; set; }

    [System.ComponentModel.DataAnnotations.Range(1, int.MaxValue)]
    public int CurrencyRef { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("Rate")]
    public double Rate { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("Date")]
    public System.DateTimeOffset? Date { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("ExpirationDate")]
    [System.ComponentModel.DataAnnotations.Required(AllowEmptyStrings = true)]
    public System.DateTimeOffset ExpirationDate { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("CustomerRef")]
    [System.ComponentModel.DataAnnotations.Range(1, int.MaxValue)]
    public int CustomerRef { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("AddressRef")]
    [System.ComponentModel.DataAnnotations.Range(1, int.MaxValue)]
    public int? AddressRef { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("SaleTypeRef")]
    [System.ComponentModel.DataAnnotations.Range(1, int.MaxValue)]
    public int SaleTypeRef { get; set; }

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

    [System.Text.Json.Serialization.JsonPropertyName("Description")]
    public string? Description { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("Items")]
    [System.ComponentModel.DataAnnotations.Required]
    public System.Collections.Generic.ICollection<NewQuotationItemDto> Items { get; set; } = new System.Collections.ObjectModel.Collection<NewQuotationItemDto>();

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}


public partial class NewQuotationItemDto
{

    [System.Text.Json.Serialization.JsonPropertyName("RowID")]
    [System.ComponentModel.DataAnnotations.Range(1, int.MaxValue)]
    public int RowID { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("ItemRef")]
    [System.ComponentModel.DataAnnotations.Range(1, int.MaxValue)]
    public int ItemRef { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("TracingRef")]
    [System.ComponentModel.DataAnnotations.Range(1, int.MaxValue)]
    public int? TracingRef { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("StockRef")]
    [System.ComponentModel.DataAnnotations.Range(1, int.MaxValue)]
    public int? StockRef { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("Quantity")]
    public double Quantity { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("SecondaryQuantity")]
    public double SecondaryQuantity { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("Fee")]
    public double Fee { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("Price")]
    public double Price { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("Description")]
    public string Description { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("PriceInfoPercentDiscount")]
    public double PriceInfoPercentDiscount { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("PriceInfoPriceDiscount")]
    public double PriceInfoPriceDiscount { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("PriceInfoDiscountRate")]
    public double PriceInfoDiscountRate { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("AggregateAmountPercentDiscount")]
    public double AggregateAmountPercentDiscount { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("AggregateAmountPriceDiscount")]
    public double AggregateAmountPriceDiscount { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("AggregateAmountDiscountRate")]
    public double AggregateAmountDiscountRate { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("CustomerDiscount")]
    public double CustomerDiscount { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("CustomerDiscountRate")]
    public double CustomerDiscountRate { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("Discount")]
    public double Discount { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("DiscountParentRef")]
    [System.ComponentModel.DataAnnotations.Range(1, int.MaxValue)]
    public int? DiscountParentRef { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("Tax")]
    public double Tax { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("Duty")]
    public double Duty { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("Addition")]
    public double Addition { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}
