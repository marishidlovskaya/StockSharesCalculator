using StockSharesCalculator.Environment.Entities;
using StockSharesCalculator.Environment.Enums;

namespace StockSharesCalculator.Test.TestData;

public static class StockTransactionTestData
{
    public static List<StockTransaction> GetStockTransactionTestData()
    {
        List<List<StockTransaction>> testData = new();

        List<StockTransaction> set1 = new()
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
                    NumberOfShares = 200,
                    TransactionType = TransactionType.Buy,
                    TransactionDate = new DateTime(2024, 2, 15),
                    TransactionPrice = 30.00m,
                }
            };

        //List<StockTransaction> set2 = new()
        //    {
        //        new StockTransaction
        //        {
        //            Id = 3,
        //            NumberOfShares = 100,
        //            TransactionType = TransactionType.Buy,
        //            TransactionDate = new DateTime(2024, 1, 15),
        //            TransactionPrice = 20.00m,
        //        },
        //        new StockTransaction
        //        {
        //            Id = 4,
        //            NumberOfShares = 150,
        //            TransactionType = TransactionType.Sell,
        //            TransactionDate = new DateTime(2024, 2, 15),
        //            TransactionPrice = 30.00m,
        //        },
        //        new StockTransaction
        //        {
        //            Id = 5,
        //            NumberOfShares = 120,
        //            TransactionType = TransactionType.Sell,
        //            TransactionDate = new DateTime(2024, 3, 15),
        //            TransactionPrice = 10.00m,
        //        }
        //    };

        //List<StockTransaction> set3 = new()
        //    {
        //        new StockTransaction
        //        {
        //            Id = 6,
        //            NumberOfShares = 0.34m,
        //            TransactionType = TransactionType.Buy,
        //            TransactionDate = new DateTime(2024, 5, 15),
        //            TransactionPrice = 17.00m,
        //        },
        //        new StockTransaction
        //        {
        //            Id = 7,
        //            NumberOfShares = 5.99m,
        //            TransactionType = TransactionType.Sell,
        //            TransactionDate = new DateTime(2024, 1, 15),
        //            TransactionPrice = 2.87m,
        //        }
        //    };

        //testData.Add(set1);
        //testData.Add(set2);
       // testData.Add(set3);

        return set1;
    }
}
