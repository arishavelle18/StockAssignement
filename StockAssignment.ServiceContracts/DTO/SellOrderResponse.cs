using StockAssignment.Entities;

namespace StockAssignment.ServiceContracts.DTO;

public class SellOrderResponse
{
    public Guid SellOrderID { get; set; }
    public string? StockSymbol { get; set; }
    public string? StockName { get; set; }
    public DateTime DateAndTimeOfOrder { get; set; }
    public UInt32 Quantity { get; set; }
    public double Price { get; set; }
    public double TradeAmount { get; set; }
    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        if(obj.GetType() != typeof(SellOrderResponse)) return false;
        //cast
        SellOrderResponse sellOrderResponse = (SellOrderResponse)obj;
        return this.SellOrderID == sellOrderResponse.SellOrderID && this.StockName == sellOrderResponse.StockName && this.DateAndTimeOfOrder == sellOrderResponse.DateAndTimeOfOrder && this.Quantity == sellOrderResponse.Quantity && this.Price == sellOrderResponse.Price && this.TradeAmount == sellOrderResponse.TradeAmount;
    }
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}

public static class SellOrderExtension
{
    public static SellOrderResponse toSellOrderResponse(this SellOrder sellOrder)
    {
        return new SellOrderResponse
        {
            SellOrderID = sellOrder.SellOrderID,
            StockSymbol = sellOrder.StockSymbol,
            StockName = sellOrder.StockName,
            Price = sellOrder.Price,
            DateAndTimeOfOrder = sellOrder.DateAndTimeOfOrder,
            Quantity = sellOrder.Quantity,
            TradeAmount = sellOrder.Price * sellOrder.Quantity
        };
    }
}