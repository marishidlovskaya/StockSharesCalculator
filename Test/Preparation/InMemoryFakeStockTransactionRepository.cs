using StockSharesCalculator.Environment.Entities;
using StockSharesCalculator.Environment.Interfaces;

namespace StockSharesCalculator.Environment.Repositories;

public class InMemoryFakeStockTransactionRepository : IStockTransactionRepository
{
    private readonly List<StockTransaction> _transactions;

    public InMemoryFakeStockTransactionRepository(List<StockTransaction> transactions)
    {
        _transactions = transactions;
    }
    public async Task<IEnumerable<StockTransaction>> GetAll()
    {
        return _transactions;
    }

    public async Task<IEnumerable<StockTransaction>> Find(Func<StockTransaction, bool> predicate)
    {
        return _transactions.Where(predicate);
    }
}
