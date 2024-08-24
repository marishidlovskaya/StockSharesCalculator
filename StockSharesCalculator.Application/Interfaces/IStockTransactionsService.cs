using StockSharesCalculator.Environment.Entities;

namespace StockSharesCalculator.Application.Interfaces;
public interface IStockTransactionsService
{
    Task<IEnumerable<StockTransaction>> GetAllStockTransactionsAsync();
}
