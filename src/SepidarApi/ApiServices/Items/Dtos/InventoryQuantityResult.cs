
namespace Honamic.SepidarApi.ApiServices.Items.Dtos;

public class InventoryQuantityResult
{
    public int StockRef { get; set; }
    public int? TracingRef { get; set; }
    public double? InventoryQuantity { get; set; }
    public double? SaleQuantity { get; set; }
    public double? SaleQuantityWithReserve { get; set; }
}