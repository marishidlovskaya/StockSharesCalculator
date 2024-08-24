using System.ComponentModel.DataAnnotations;

namespace StockSharesCalculator.Web.Models
{
    public class ShareSaleViewModel
    {
        [Required(ErrorMessage = "Please enter the number of shares.")]
        [Range(1, int.MaxValue, ErrorMessage = "Number of shares must be greater than zero.")]
        [Display(Name = "Number of Shares")]
        public int NumberOfShares { get; set; }

        [Required(ErrorMessage = "Please enter the price per share.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price per share must be greater than zero.")]
        [Display(Name = "Price per Share")]
        public decimal PricePerShare { get; set; }
    }
}
