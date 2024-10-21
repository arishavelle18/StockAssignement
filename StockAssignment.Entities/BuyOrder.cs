using System.ComponentModel.DataAnnotations;

namespace StockAssignment.Entities;

/// <summary>
/// model for buying order model
/// </summary>
public class BuyOrder
{
    public Guid BuyOrderID { get; set; }
    [Required(ErrorMessage = "Stock Symbol must required")]
    public string? StockSymbol { get; set; }
    [Required(ErrorMessage = "Stock Name must required")]
    public string? StockName { get; set; }
    public DateTime DateAndTimeOfOrder { get; set; }
    [Range(1, 100000)]
    public UInt32 Quantity { get; set; }
    [Range(1.00, 100000.00)]
    public double Price { get; set; }
}
