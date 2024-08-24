using StockSharesCalculator.Application;
using StockSharesCalculator.Application.Interfaces;
using StockSharesCalculator.Application.Services;
using StockSharesCalculator.Environment.Entities;
using StockSharesCalculator.Environment.Enums;
using StockSharesCalculator.Environment.Repositories;
using StockSharesCalculator.Test.TestData;

namespace Test;
public class StockCalculationServiceFIFOTests
{
    //Mock  
    private readonly IStockCalculationServiceFIFO _service;

    [Fact]
    public async Task CalculateResult_ValidInputs_ReturnsCorrectCalculation()
    {
        //List<List<StockTransaction>> testSets = StockTransactionTestData.GetStockTransactionTestData();
        //List<CalculationResultFIFO> results = new();
        //foreach (var testSet in testSets) 
        //{
        //    var repository = new InMemoryFakeStockTransactionRepository(testSet);
        //    var service = new StockCalculationServiceFIFO(repository);


        //    decimal soldShares = 150;
        //    decimal salePrice = 40;

        //    // Act
        //    var result = await service.CalculateResult(soldShares, salePrice);
        //    results.Add(result);
        //}

        //    // Assert
        //    Assert.Equal(150, results[0].RemainingShares);
        //    Assert.Equal(23.33m, results[0].CostBasisOfSoldShares);
        //    Assert.Equal(30.00m, results[0].CostBasisOfRemainingShares);
        //    Assert.Equal(2500.0m, results[0].Profit);
    }

    [Fact]
    public async Task CalculateResult_SoldSharesExceedsTotalShares_ThrowsInvalidOperationException()
    {
        //// Arrange
        //var transactions = new List<StockTransaction>
        //{
        //    new StockTransaction { TransactionType = TransactionType.Buy, NumberOfShares = 100, TransactionPrice = 20, TransactionDate = new DateTime(2023, 1, 1) }
        //};

        ////_mockStockTransactionRepository.Setup(repo => repo.GetAll()).Returns(transactions);

        //decimal soldShares = 150;
        //decimal salePrice = 40;

        //// Act & Assert
        //await Assert.ThrowsAsync<InvalidOperationException>(() => _service.CalculateResult(soldShares, salePrice));
    }

    //[Fact]
    //public async Task CalculateResult_NoTransactionsFound_ThrowsInvalidOperationException()
    //{
    //    // Arrange
    //    _mockStockTransactionRepository.Setup(repo => repo.GetAll()).Returns(new List<StockTransaction>());

    //    decimal soldShares = 100;
    //    decimal salePrice = 40;

    //    // Act & Assert
    //    await Assert.ThrowsAsync<InvalidOperationException>(() => _service.CalculateResult(soldShares, salePrice));
    //}

    //[Fact]
    //public async Task CalculateResult_SoldSharesZero_ThrowsArgumentException()
    //{
    //    // Arrange
    //    decimal soldShares = 0;
    //    decimal salePrice = 40;

    //    // Act & Assert
    //    await Assert.ThrowsAsync<ArgumentException>(() => _service.CalculateResult(soldShares, salePrice));
    //}

    //[Fact]
    //public async Task CalculateResult_SalePriceZero_ThrowsArgumentException()
    //{
    //    // Arrange
    //    decimal soldShares = 100;
    //    decimal salePrice = 0;

    //    // Act & Assert
    //    await Assert.ThrowsAsync<ArgumentException>(() => _service.CalculateResult(soldShares, salePrice));
    //}
}