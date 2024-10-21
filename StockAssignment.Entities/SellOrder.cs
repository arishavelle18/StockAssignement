using System.ComponentModel.DataAnnotations;

namespace StockAssignment.Entities;
/// <summary>
/// model for selling order model
/// </summary>
public class SellOrder
{
    public Guid SellOrderID { get; set; }
    [Required(ErrorMessage = "Stock Symbol must required")]
    public string? StockSymbol { get; set; }
    [Required(ErrorMessage = "Stock Name must required")]
    public string? StockName { get; set; }
    public DateTime DateAndTimeOfOrder { get; set; }
    [Range(1u, 100000u)]
    public UInt32 Quantity { get; set; }
    [Range(1.00, 100000.00)]
    public double Price { get; set; }

   
}
