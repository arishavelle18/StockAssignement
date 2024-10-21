using StockAssignment.Entities;
using StockAssignment.ServiceContracts.Helpers;
using System.ComponentModel.DataAnnotations;

namespace StockAssignment.ServiceContracts.DTO;

public class BuyOrderRequest
{
    [Required(ErrorMessage = "Stock Symbol must required")]
    public string? StockSymbol { get; set; }
    [Required(ErrorMessage = "Stock Name must required")]
    public string? StockName { get; set; }
    [DateTimeValidation("2000-01-01")]
    public DateTime DateAndTimeOfOrder { get; set; }
    [Range(1u, 100000u,ErrorMessage ="Value must be between 1-100000.")]
    public UInt32 Quantity { get; set; }
    [Range(1.00, 100000.00, ErrorMessage = "Value must be between 1-100000.")]
    public double Price { get; set; }

    public BuyOrder ToBuyOrder()
    {
        return new BuyOrder
        {
            BuyOrderID = Guid.NewGuid(),
            StockSymbol = StockSymbol,
            StockName = StockName,
            DateAndTimeOfOrder = DateAndTimeOfOrder,
            Quantity = Quantity,
            Price = Price
        };
    }
}
