namespace Honamic.SepidarApi.Services.Items.Dtos;

public partial class ItemResult
{
    public override string ToString()
    {
        return $"{ItemID}-{Title}";
    }


    [System.Text.Json.Serialization.JsonPropertyName("ItemID")]
    [System.ComponentModel.DataAnnotations.Range(1, int.MaxValue)]
    public int ItemID { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("Code")]
    public string Code { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("Barcode")]
    public string Barcode { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("Title")]
    public string Title { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("IsActive")]
    public bool IsActive { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("IsSellable")]
    public bool IsSellable { get; set; }


    [System.Text.Json.Serialization.JsonPropertyName("Type")]
    public ItemType Type { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("UnitRef")]
    [System.ComponentModel.DataAnnotations.Range(1, int.MaxValue)]
    public int UnitRef { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("SecondaryUnitRef")]
    [System.ComponentModel.DataAnnotations.Range(1, int.MaxValue)]
    public int? SecondaryUnitRef { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("UnitsRatio")]
    public double? UnitsRatio { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("IsUnitRatioConstant")]
    public bool IsUnitRatioConstant { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("Weight")]
    public double? Weight { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("Volume")]
    public double? Volume { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("Tracings")]
    public ICollection<Tracings> Tracings { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("TracingInventories")]
    public ICollection<TracingInventories> TracingInventories { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("TotalInventory")]
    public double TotalInventory { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("PropertyValues")]
    public ICollection<PropertyValues> PropertyValues { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("Thumbnail")]
    public byte[] Thumbnail { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("IsTaxExempt")]
    public bool IsTaxExempt { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("TaxRate")]
    public double TaxRate { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("DutyRate")]
    public double DutyRate { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("BrokerSellable")]
    public bool BrokerSellable { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("SaleGroupRef")]
    [System.ComponentModel.DataAnnotations.Range(1, int.MaxValue)]
    public int? SaleGroupRef { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("CodingGroupRef")]
    public int? CodingGroupRef { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("PurchaseGroupRef")]
    public int? PurchaseGroupRef { get; set; }

    private IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}