using StockSharesCalculator.Environment.Entities;
using StockSharesCalculator.Environment.Interfaces;

namespace StockSharesCalculator.Environment.Repositories;

public class FakeStockTransactionRepository : IStockTransactionRepository
{
    private readonly List<StockTransaction> _transactions;

    public FakeStockTransactionRepository(List<StockTransaction> transactions)
    {
        _transactions = transactions;
    }
    public async Task<IEnumerable<StockTransaction>> GetAll()
    {
        // Simulate asynchronous fake data fetching
        return await Task.FromResult(_transactions);
    }
    public async Task<IEnumerable<StockTransaction>> Find(Func<StockTransaction, bool> predicate)
    {
        // Simulate asynchronous fake data fetching
        return await Task.FromResult(_transactions.Where(predicate));
    }
}
