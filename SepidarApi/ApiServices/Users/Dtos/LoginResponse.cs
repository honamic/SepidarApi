namespace Honamic.SepidarApi.Services.Users.Dtos;

public class LoginResponse
{
    public string Token { get; set; }
    public int UserID { get; set; }
    public string Title { get; set; }
    public bool CanEditCustomer { get; set; }
    public bool CanRegisterCustomer { get; set; }
    public bool CanRegisterOrder { get; set; }
    public bool CanRegisterReturnOrder { get; set; }
    public bool CanRegisterInvoice { get; set; }
    public bool CanRegisterReturnInvoice { get; set; }
    public bool CanPrintInvoice { get; set; }
    public bool CanPrintReturnInvoice { get; set; }
    public bool CanPrintInvoiceBeforeSend { get; set; }
    public bool CanPrintReturnInvoiceBeforeSend { get; set; }
    public bool CanRevokeInvoice { get; set; }

    public bool CanBypassLocationCheck { get; set; }
    public bool CanBypassLocationCheckInHotInvoice { get; set; }
    public bool CanDebtCollect { get; set; }
    public bool CanDistribute { get; set; }
    public bool CanEditAdditions { get; set; }
    public bool CanEditDiscount { get; set; }
    public bool CanEditTaxAndDuty { get; set; }
    public bool CanPrintInvoiceWithRemainder { get; set; }
    public bool CanPrintPartyBillReport { get; set; }
    public bool CanRevokeReturnInvoice { get; set; }

    public override string ToString()
    {
        return $"{Title}- {UserID}";
    }
}
