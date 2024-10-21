using StockAssignment.Entities;
using StockAssignment.ServiceContracts.Helpers;
using System.ComponentModel.DataAnnotations;

namespace StockAssignment.ServiceContracts.DTO;

public class SellOrderRequest
{
    [Required(ErrorMessage = "Stock Symbol must required")]
    public string? StockSymbol { get; set; }
    [Required(ErrorMessage = "Stock Name must required")]
    public string? StockName { get; set; }
    //[DateTimeValidation("2000-01-01")]
    public DateTime DateAndTimeOfOrder { get; set; }
    [Range(1, 100000)]
    public UInt32 Quantity { get; set; }
    [Range(1.00, 100000.00)]
    public double Price { get; set; }
    public SellOrder ToSellOrder()
    {
        return new SellOrder
        {
            SellOrderID = Guid.NewGuid(),
            StockSymbol = StockSymbol,
            StockName = StockName,
            DateAndTimeOfOrder = DateAndTimeOfOrder,
            Quantity = Quantity,
            Price = Price
        };
    }
}

