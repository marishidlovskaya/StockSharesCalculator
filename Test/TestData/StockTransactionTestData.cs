using StockSharesCalculator.Environment.Entities;
using StockSharesCalculator.Environment.Enums;

namespace StockSharesCalculator.Test.TestData;

internal static class StockTransactionTestData
{
    public static IEnumerable<object[]> GetStockTransactions()
    {
        yield return new object[]
          {
                new List<StockTransaction>
                {
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
                }
          };
    }
}
