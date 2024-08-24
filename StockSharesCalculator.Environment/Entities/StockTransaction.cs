using StockSharesCalculator.Environment.Enums;

namespace StockSharesCalculator.Environment.Entities;
public class StockTransaction
{
    public int Id { get; set; }
    //public int UserId { get; set; }
    //public string StockName { get; set; }

    public decimal NumberOfShares { get; set; }
    public TransactionType TransactionType { get; set; }
    public DateTime TransactionDate { get; set; }
    public decimal TransactionPrice { get; set; }    
}
