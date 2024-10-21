using StockAssignment.Entities;

namespace StockAssignment.ServiceContracts.DTO;

public class BuyOrderResponse
{
    public Guid BuyOrderID { get; set; }
    public string? StockSymbol { get; set; }
    public string? StockName { get; set; }
    public DateTime DateAndTimeOfOrder { get; set; }
    public UInt32 Quantity { get; set; }
    public double Price { get; set; }
    public double TradeAmount { get; set; }
    public override bool Equals(object? obj)
    {
        // check if null
        if (obj == null) return false;
        // check if the get type is not equal to model then return false
        if (obj.GetType() != typeof(BuyOrderResponse)) return false;
        // type cast
        BuyOrderResponse buyOrderResponse = (BuyOrderResponse)obj;
        return this.BuyOrderID == buyOrderResponse.BuyOrderID && this.StockSymbol == buyOrderResponse.StockSymbol && this.StockName == buyOrderResponse.StockName && this.DateAndTimeOfOrder == DateAndTimeOfOrder && this.Quantity == buyOrderResponse.Quantity && this.Price == buyOrderResponse.Price && this.TradeAmount == buyOrderResponse.TradeAmount;
    }
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
public static class BuyOrderExtension
{
    public static BuyOrderResponse ToBuyOrderResponse(this BuyOrder buyOrder)
    {
        return new BuyOrderResponse
        {
            BuyOrderID = buyOrder.BuyOrderID,
            StockSymbol = buyOrder.StockSymbol,
            StockName = buyOrder.StockName,
            Price = buyOrder.Price,
            DateAndTimeOfOrder = buyOrder.DateAndTimeOfOrder,
            Quantity = buyOrder.Quantity,
            TradeAmount = buyOrder.Price * buyOrder.Quantity

        };
    }
}
