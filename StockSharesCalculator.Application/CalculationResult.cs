namespace StockSharesCalculator.Application;

public class CalculationResult
{
    public decimal RemainingShares { get; set; }
    public decimal CostBasisOfSoldShares { get; set; }
    public decimal CostBasisOfRemainingShares { get; set; }
    public decimal Profit { get; set; }
}
