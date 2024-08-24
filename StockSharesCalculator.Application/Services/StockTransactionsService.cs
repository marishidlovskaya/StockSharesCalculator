using StockSharesCalculator.Application.Interfaces;
using StockSharesCalculator.Environment.Entities;
using StockSharesCalculator.Environment.Interfaces;

namespace StockSharesCalculator.Application.Services;

public class StockTransactionsService : IStockTransactionsService
{
    private readonly IStockTransactionRepository _stockTransactionRepository;

    public StockTransactionsService(IStockTransactionRepository stockTransactionRepository)
    {
        _stockTransactionRepository = stockTransactionRepository;
    }

    public async Task<IEnumerable<StockTransaction>> GetAllStockTransactionsAsync()
    {
        return await _stockTransactionRepository.GetAll();
    }
}
