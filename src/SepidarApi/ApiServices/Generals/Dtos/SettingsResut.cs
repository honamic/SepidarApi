namespace Honamic.SepidarApi.ApiServices.Units.Dtos;

public class SettingsResut
{
    public bool ShowInventoryQuantityOnMobile { get; set; }
    public int? ItemsWeightUnitRef { get; set; }
    public int? ItemsVolumeUnitRef { get; set; }
    public bool CheckOrderingLocation { get; set; }
    public int PermittedOrderingLocationRange { get; set; }
    public bool CheckHotInvoiceLocation { get; set; }
    public int PermittedHotInvoiceLocationRange { get; set; }
    public bool EnableMobileRefreshBasicInfo { get; set; }
    public int RefreshTimeSpan { get; set; }
    public bool DiscountOnCustomer { get; set; }
}
