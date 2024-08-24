using StockSharesCalculator.Application.Interfaces;
using StockSharesCalculator.Environment.Entities;
using StockSharesCalculator.Environment.Enums;

namespace StockSharesCalculator.Application.Services;

public class StockCalculationFIFOService : IStockCalculationService
{
    public CalculationResult CalculateResult(IEnumerable<StockTransaction> transactions, decimal soldShares, decimal salePrice)
    {
        if (!transactions.Any())
            throw new InvalidOperationException("No transactions found");

        decimal totalShares = IStockCalculationService.GetTotalShares(transactions);
        if (soldShares > totalShares)
            throw new InvalidOperationException($"The number of shares sold ({soldShares}) exceeds the available shares ({totalShares})");

        decimal remainingShares = totalShares - soldShares;
        decimal costBasisOfSoldShares = CalculateCostBasis(transactions, soldShares, isSoldTransaction: true);
        decimal costBasisOfRemainingShares = CalculateCostBasis(transactions, remainingShares, isSoldTransaction: false);
        decimal profit = CalculateTotalProfitOrLoss(costBasisOfSoldShares, soldShares, salePrice);

        return new CalculationResult
        {
            RemainingShares = Math.Round(remainingShares, 2, MidpointRounding.AwayFromZero),
            CostBasisOfSoldShares = Math.Round(costBasisOfSoldShares, 2, MidpointRounding.AwayFromZero),
            CostBasisOfRemainingShares = Math.Round(costBasisOfRemainingShares, 2, MidpointRounding.AwayFromZero),
            Profit = Math.Round(profit, 2, MidpointRounding.AwayFromZero)
        };
    }

    private decimal CalculateCostBasis(IEnumerable<StockTransaction> transactions, decimal sharesToCalculate, bool isSoldTransaction)
    {
        IEnumerable<StockTransaction> filteredTransactions = transactions
            .Where(t => t.TransactionType == TransactionType.Buy);

        // Sort transactions based on whether we are calculating cost basis for sold or remaining shares
        List<StockTransaction> sortedTransactions = isSoldTransaction
            ? filteredTransactions.OrderBy(t => t.TransactionDate).ToList()
            : filteredTransactions.OrderByDescending(t => t.TransactionDate).ToList();

        decimal totalCostBasis = 0;
        decimal remainingShares = sharesToCalculate;

        foreach (StockTransaction transaction in sortedTransactions)
        {
            if (remainingShares <= 0)
                break;

            decimal shares = Math.Min(transaction.NumberOfShares, remainingShares);
            totalCostBasis += shares * transaction.TransactionPrice;
            remainingShares -= shares;
        }

        if (remainingShares > 0)
            throw new InvalidOperationException(isSoldTransaction
                ? "Not enough shares to sell."
                : "Remaining shares calculation error.");

        return totalCostBasis / sharesToCalculate;
    }
    private decimal CalculateTotalProfitOrLoss(decimal costBasisOfSoldShares, decimal soldShares, decimal salePrice)
    {
        decimal totalCostBasisOfSoldShares = costBasisOfSoldShares * soldShares;
        decimal totalSaleValue = salePrice * soldShares;

        return totalSaleValue - totalCostBasisOfSoldShares;
    }
}
