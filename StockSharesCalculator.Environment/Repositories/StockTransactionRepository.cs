using StockSharesCalculator.Environment.Entities;
using StockSharesCalculator.Environment.Enums;
using StockSharesCalculator.Environment.Interfaces;


namespace StockSharesCalculator.Environment.Repositories
{
    public class StockTransactionRepository : IStockTransactionRepository
    {
        private readonly List<StockTransaction> _transactions;

        public StockTransactionRepository()
        {
            // Initialize with sample data
            _transactions = [
                new StockTransaction
                {
                    Id = 1,
                    NumberOfShares = 100,
                    TransactionType = TransactionType.Buy,
                    TransactionDate = new DateTime(2024, 1, 15),
                    TransactionPrice = 20.00m,
                },
                new StockTransaction
                {
                    Id = 2,
                    NumberOfShares = 150,
                    TransactionType = TransactionType.Buy,
                    TransactionDate = new DateTime(2024, 2, 15),
                    TransactionPrice = 30.00m,
                },
                new StockTransaction
                {
                    Id = 3,
                    NumberOfShares = 120,
                    TransactionType = TransactionType.Buy,
                    TransactionDate = new DateTime(2024, 3, 15),
                    TransactionPrice = 10.00m,
                }
           ];
        }
        public async Task<IEnumerable<StockTransaction>> GetAll()
        {
            // Simulate asynchronous data fetching
            return await Task.FromResult( _transactions );
        }

        public async Task<IEnumerable<StockTransaction>> Find(Func<StockTransaction, bool> predicate)
        {
            // Simulate asynchronous data fetching
            return await Task.FromResult(_transactions.Where(predicate));
        }
    }
}
