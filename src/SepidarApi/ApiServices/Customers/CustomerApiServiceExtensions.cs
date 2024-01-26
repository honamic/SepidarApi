using Honamic.SepidarApi.Services.Customers.Dtos;

namespace Honamic.SepidarApi.Services.Customers;
public static class CustomerApiServiceExtensions
{
    /// <summary>
    /// It works through receive all and may be slow.
    /// </summary>
    public static async Task<CustomerResult?> GetCustomerByCode(this CustomerApiService apiService, string code, bool fulldetails)
    {
        var customers = await apiService.GetCustomers();

        var find = customers.FirstOrDefault(x => x.Code == code);

        if (find is null)
            return find;

        if (!fulldetails)
            return find;

        return await apiService.GetCustomer(find.CustomerID);
    }
}