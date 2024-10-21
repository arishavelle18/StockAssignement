using StockAssignment.Entities;
using StockAssignment.Service.Helpers;
using StockAssignment.ServiceContracts;
using StockAssignment.ServiceContracts.DTO;

namespace StockAssignment.Service;

public class StocksService : IStocksService
{
    private readonly List<BuyOrder> _buyOrders;
    private readonly List<SellOrder> _sellOrders;
    private bool initialize;
    public StocksService()
    {

            _buyOrders = new List<BuyOrder>();
            _sellOrders = new List<SellOrder>();
    }
    //CreateBuyOrder: Inserts a new buy order into the database table called 'BuyOrders'.
    public async Task<BuyOrderResponse> CreateBuyOrder(BuyOrderRequest? buyOrderRequest)
    {
        if (buyOrderRequest == null)
            throw new ArgumentNullException(nameof(buyOrderRequest));
        ValidationHelper.ModelValidation(buyOrderRequest);
        BuyOrder buyOrder = buyOrderRequest.ToBuyOrder();
        _buyOrders.Add(buyOrder);
        return buyOrder.ToBuyOrderResponse();
    }
    //CreateSellOrder: Inserts a new sell order into the database table called 'SellOrders'.
    public async Task<SellOrderResponse> CreateSellOrder(SellOrderRequest? sellOrderRequest)
    {
        if(sellOrderRequest == null)
            throw new ArgumentNullException(nameof(sellOrderRequest));
        ValidationHelper.ModelValidation(sellOrderRequest);
        SellOrder sellOrder = sellOrderRequest.ToSellOrder();
        _sellOrders.Add(sellOrder);
        return sellOrder.toSellOrderResponse();
    }

    //GetBuyOrders: Returns the existing list of buy orders retrieved from database table called 'BuyOrders'.

    public async Task<List<BuyOrderResponse>> GetBuyOrders()
    {
        return _buyOrders.Select(buyOrder => buyOrder.ToBuyOrderResponse()).ToList();
    }
    //GetSellOrders: Returns the existing list of sell orders retrieved from database table called 'SellOrders'.
    public async Task<List<SellOrderResponse>> GetSellOrders()
    {
        return _sellOrders.Select(sellOrder => sellOrder.toSellOrderResponse()).ToList();
    }
}
