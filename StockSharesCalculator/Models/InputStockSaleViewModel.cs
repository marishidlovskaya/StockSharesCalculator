using System.ComponentModel.DataAnnotations;

namespace StockSharesCalculator.Web.Models;

public class InputStockSaleViewModel
{
    [Required(ErrorMessage = "Please enter the number of shares.")]
    [Range(1, 10000000, ErrorMessage = "Number of shares must be between 1 and 10,000,000.")]
    [Display(Name = "Number of Shares")]
    public int NumberOfShares { get; set; }

    [Required(ErrorMessage = "Please enter the price per share.")]
    [Range(0.01, 10000000000, ErrorMessage = "Price per share must be between 0.01 and 10,000,000,000")]
    [Display(Name = "Price per Share")]
    public decimal PricePerShare { get; set; }
}
