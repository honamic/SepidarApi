
using System.ComponentModel;

namespace Honamic.SepidarApi.ApiServices.Quotations.Dtos;

public partial class QuotationItemResult
{
    [DisplayName("شناسه قلم پیش فاكتور")]
    public int QuotationItemID { get; set; }

    [DisplayName("شماره ردیف")]
    public int RowID { get; set; }

    [DisplayName("شناسه كالا")]
    public int ItemRef { get; set; }

    [DisplayName("شناسه عامل ردیابی ")]
    public int? TracingRef { get; set; }

    [DisplayName("شناسه انبار")]
    public int? StockRef { get; set; }

    [DisplayName("تعداد واحد اصلی")]
    public double Quantity { get; set; }

    [DisplayName("تعداد واحد فرعی ")]
    public double? SecondaryQuantity { get; set; }

    [DisplayName("فی")]
    public double Fee { get; set; }

    [DisplayName("مبلغ ناخالص")]
    public double Price { get; set; }

    [DisplayName("توضیحات")]
    public string Description { get; set; }



    [DisplayName("تخفیف درصدی اعلامیه قیمت")]
    public double PriceInfoPercentDiscount { get; set; }

    [DisplayName("تخفیف مبلغی اعلامیه قیمت")]
    public double PriceInfoPriceDiscount { get; set; }

    [DisplayName("نرخ تخفیف اعلامیه قیمت")]
    public double PriceInfoDiscountRate { get; set; }



    [DisplayName("تخفیف درصدی سرجمع")]
    public double AggregateAmountPercentDiscount { get; set; }

    [DisplayName("تخفیف مبلغی سرجمع ")]
    public double AggregateAmountPriceDiscount { get; set; }

    [DisplayName("نرخ تخفیف سرجمع")]
    public double AggregateAmountDiscountRate { get; set; }



    [DisplayName("تخفیف مشتری")]
    public double CustomerDiscount { get; set; }

    [DisplayName("نرخ تخفیف مشتری")]
    public double CustomerDiscountRate { get; set; }



    [DisplayName("تخفیف")]
    public double Discount { get; set; }

    [DisplayName("شناسه تخفیف")]
    public int? DiscountParentRef { get; set; }


    [DisplayName("مالیات")]
    public double Tax { get; set; }

    [DisplayName("عوارض")]
    public double Duty { get; set; }

    [DisplayName("اضافات")]
    public double Addition { get; set; }

    [DisplayName("مبلغ خالص")]
    public double NetPrice { get; set; }

    private System.Collections.Generic.IDictionary<string, object> _additionalProperties;

    [System.Text.Json.Serialization.JsonExtensionData]
    public System.Collections.Generic.IDictionary<string, object> AdditionalProperties
    {
        get { return _additionalProperties ?? (_additionalProperties = new System.Collections.Generic.Dictionary<string, object>()); }
        set { _additionalProperties = value; }
    }

}