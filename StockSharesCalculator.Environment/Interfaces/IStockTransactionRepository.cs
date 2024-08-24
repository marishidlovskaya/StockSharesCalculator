using StockSharesCalculator.Environment.Entities;

namespace StockSharesCalculator.Environment.Interfaces
{
    public interface IStockTransactionRepository
    {
        Task<IEnumerable<StockTransaction>> GetAll();
        Task<IEnumerable<StockTransaction>> Find(Func<StockTransaction, bool> predicate);
    }
}
