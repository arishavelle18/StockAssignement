using StockAssignment.ServiceContracts.DTO;

namespace StockAssignment.ServiceContracts;

public interface IStocksService
{
    //CreateBuyOrder: Inserts a new buy order into the database table called 'BuyOrders'.
    Task<BuyOrderResponse> CreateBuyOrder(BuyOrderRequest? buyOrderRequest);
    //CreateSellOrder: Inserts a new sell order into the database table called 'SellOrders'.
    Task<SellOrderResponse> CreateSellOrder(SellOrderRequest? sellOrderRequest);
    //GetBuyOrders: Returns the existing list of buy orders retrieved from database table called 'BuyOrders'.
    Task<List<BuyOrderResponse>> GetBuyOrders();
    //GetSellOrders: Returns the existing list of sell orders retrieved from database table called 'SellOrders'.
    Task<List<SellOrderResponse>> GetSellOrders();
}
