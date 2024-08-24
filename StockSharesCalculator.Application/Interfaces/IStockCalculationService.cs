using StockSharesCalculator.Environment.Entities;
using StockSharesCalculator.Environment.Enums;

namespace StockSharesCalculator.Application.Interfaces;
public interface IStockCalculationService
{
    CalculationResult CalculateResult(IEnumerable<StockTransaction> transactions, decimal soldShares, decimal salePrice);

    protected static decimal GetTotalShares(IEnumerable<StockTransaction> transactions)
    {
        return transactions
            .Where(t => t.TransactionType == TransactionType.Buy)
            .Sum(t => t.NumberOfShares) -
            transactions
            .Where(t => t.TransactionType == TransactionType.Sell)
            .Sum(t => t.NumberOfShares);
    }
}
