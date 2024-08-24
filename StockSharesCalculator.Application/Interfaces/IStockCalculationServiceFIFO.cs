using StockSharesCalculator.Environment.Entities;

namespace StockSharesCalculator.Application.Interfaces;
public interface IStockCalculationServiceFIFO
{
    CalculationResultFIFO CalculateResult(IEnumerable<StockTransaction> transactions, decimal soldShares, decimal salePrice);
}
