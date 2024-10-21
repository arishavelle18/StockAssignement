using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using StockAssignement.Models;
using StockAssignment.ServiceContracts;
using StockAssignment.ServiceContracts.DTO;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace StockAssignement.Controllers;

[Route("[controller]")]
public class TradeController : Controller
{
    private readonly IStocksService _stocksService;
    private readonly IFinnhubService _finnhubService;
    public TradeController(IFinnhubService finnhubService,IStocksService stocksService)
    {
        _finnhubService = finnhubService;
        _stocksService = stocksService;
    }
    [Route("index")]
    [Route("/")]
    public async Task<IActionResult> Index(List<string>? errors = null,string? success = null)
    {
        Dictionary<string, object>? getCompanyProfile = await _finnhubService.GetCompanyProfile("AAPL");
        Dictionary<string, object>? getQuotes = await _finnhubService.GetStockPriceQuote("AAPL");

        StockTrade stockTrade = new StockTrade()
        {
            StockSymbol = "MSFT"
        };
        if (getCompanyProfile != null && getQuotes != null)
        {

            stockTrade = new StockTrade
            {
                StockName = getCompanyProfile["name"]?.ToString(),
                StockSymbol = getCompanyProfile["ticker"]?.ToString(),
                Price = Convert.ToDouble(getQuotes["c"]?.ToString()),
                Quantity = 0
            };
        }
        ViewBag.Errors = errors;
        ViewBag.Success = success;
        return View(stockTrade);
    }

    [Route("sellOrder")]
    [HttpPost]
    public async Task<IActionResult> SellOrder(SellOrderRequest sellOrderRequest)
    {
        sellOrderRequest.DateAndTimeOfOrder = DateTime.Now;
        //reset the model if you are updating data
        ModelState.Clear();
        TryValidateModel(sellOrderRequest);
        if (ModelState.IsValid)
        {
            SellOrderResponse sellOrderResponse =  await _stocksService.CreateSellOrder(sellOrderRequest);
            string Success = "Sell Order is Successfully Processed";
            return RedirectToAction("Index", "Trade", new { success = Success });
        }
        List<string> Errors = ModelState.Values.SelectMany(v => v.Errors).Select(error => error.ErrorMessage).ToList();
        return RedirectToAction("Index", "Trade",new { errors = Errors });
    }

    [Route("buyOrder")]
    [HttpPost]
    public async Task<IActionResult> BuyOrder(BuyOrderRequest buyOrderRequest)
    {
        buyOrderRequest.DateAndTimeOfOrder = DateTime.Now;
        // reset the model if you are updating data
        ModelState.Clear();
        TryValidateModel(buyOrderRequest);

        if (ModelState.IsValid)
        {
            BuyOrderResponse buyOrderResponse = await _stocksService.CreateBuyOrder(buyOrderRequest);
            string Success = "Buy Order is Successfully Processed";
            return RedirectToAction("Index", "Trade", new { success = Success });
        }
        List<string> Errors = ModelState.Values.SelectMany(v => v.Errors).Select(error => error.ErrorMessage).ToList();
        return RedirectToAction("Index", "Trade", new { errors = Errors });
    }
    [Route("orders")]
    public async Task<IActionResult> Orders()
    {
        List<BuyOrderResponse> buyOrderResponses =  await _stocksService.GetBuyOrders();
        List<SellOrderResponse> sellOrderResponses = await _stocksService.GetSellOrders();
        ViewBag.BuyOrders = buyOrderResponses;
        ViewBag.SellOrders = sellOrderResponses;
        return View();
    }
}
