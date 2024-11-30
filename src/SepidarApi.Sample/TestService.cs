using Honamic.SepidarApi.ApiServices.Stocks;
using Honamic.SepidarApi.Options;
using Honamic.SepidarApi.Services.Customers;
using Honamic.SepidarApi.Services.Items;
using Honamic.SepidarApi.Services.Users;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Diagnostics;


public class TestService : ITestService
{
    private readonly ILogger<TestService> _logger;
    private readonly IOptionsMonitor<SepidarApiOptions> options;
    private readonly UserApiService userService;
    private readonly ItemApiService itemService;
    private readonly CustomerApiService customerService;
    private readonly StockApiService stockApiService;
    private readonly SaleTypeApiService saleTypeApiService;

    public TestService(ILogger<TestService> logger,
        IOptionsMonitor<SepidarApiOptions> sepidarOptions,
        UserApiService userService,
        ItemApiService itemService,
        CustomerApiService customerService,
        StockApiService stockApiService,
        SaleTypeApiService saleTypeApiService)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        this.options = sepidarOptions;
        this.userService = userService;
        this.itemService = itemService;
        this.customerService = customerService;
        this.stockApiService = stockApiService;
        this.saleTypeApiService = saleTypeApiService;
    }

    public async void Run()
    {
        _logger.LogWarning("start ...");

        if (options.CurrentValue.AutoLogin)
        {
            _logger.LogWarning("Auto login is enabled");
        }
        else
        {
            var loginResult = await userService.Login(options.CurrentValue.Username, options.CurrentValue.Password);
            _logger.LogWarning($"login as {loginResult}");
        }

        var Inventories = await itemService.GetInventories();
        _logger.LogWarning($"Inventories count {Inventories.Count()}");

        var items = await itemService.GetItems();
        _logger.LogWarning($"items count {items.Count()}");

        var item = await itemService.GetItem(items.LastOrDefault().ItemID);
        _logger.LogWarning($"item: {item}");

        var customers = await customerService.GetCustomers();
        _logger.LogWarning($"customers count {items.Count()}");

        var customer = await customerService.GetCustomer(customers.LastOrDefault().CustomerID);
        _logger.LogWarning($"customer: {customer}");
      
        var stocks = await stockApiService.GetStocks();
        _logger.LogWarning($"stocks: {stocks}");


        var saleTypes = await saleTypeApiService.GetSaleTypes();
        _logger.LogWarning($"saleTypes: {saleTypes}");

        Debugger.Break();
    }
}