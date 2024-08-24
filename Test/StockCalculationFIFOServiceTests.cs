using StockSharesCalculator.Application.Services;
using StockSharesCalculator.Environment.Entities;
using StockSharesCalculator.Environment.Repositories;
using StockSharesCalculator.Test.TestData;

namespace Test;
public class StockCalculationFIFOServiceTests
{
    [Theory]
    [MemberData(nameof(StockTransactionTestData.GetStockTransactions),
        MemberType = typeof(StockTransactionTestData))]
    public void CalculateResult_ValidInputs_ReturnsCorrectCalculation(List<StockTransaction> testTransactions)
    {
        //Arrange
        var repository = new FakeStockTransactionRepository(testTransactions);
        var service = new StockCalculationFIFOService();

        decimal soldShares = 150;
        decimal salePrice = 40;

        // Act
        var result = service.CalculateResult(testTransactions, soldShares, salePrice);

        // Assert
        Assert.Equal(220, result.RemainingShares);
        Assert.Equal(23.33m, result.CostBasisOfSoldShares);
        Assert.Equal(19.09m, result.CostBasisOfRemainingShares);
        Assert.Equal(2500.0m, result.Profit);
    }

    [Theory]
    [MemberData(nameof(StockTransactionTestData.GetStockTransactions),
    MemberType = typeof(StockTransactionTestData))]
    public void CalculateResult_InputsMaxSalePrice_ReturnsCorrectCalculation(List<StockTransaction> testTransactions)
    {
        //Arrange
        var repository = new FakeStockTransactionRepository(testTransactions);
        var service = new StockCalculationFIFOService();

        decimal soldShares = 10;
        decimal salePrice = 10000000000;

        // Act
        var result = service.CalculateResult(testTransactions, soldShares, salePrice);

        // Assert
        Assert.Equal(360, result.RemainingShares);
        Assert.Equal(20.00m, result.CostBasisOfSoldShares);
        Assert.Equal(20.83m, result.CostBasisOfRemainingShares);
        Assert.Equal(99999999800.00m, result.Profit);
    }
}