using StockSharesCalculator.Application.Interfaces;
using StockSharesCalculator.Application.Services;
using StockSharesCalculator.Web.Enums;
using StockSharesCalculator.Web.Interfaces;

namespace StockSharesCalculator.Web.Services
{
    public class StockCalculationServiceFactory : IStockCalculationServiceFactory
    {
        public IStockCalculationService GetCalculatorService(CalculationStrategy strategy)
        {
            IStockCalculationService service = strategy switch
            {
                CalculationStrategy.FIFO => new StockCalculationFIFOService(),
                _ => throw new InvalidOperationException("Unsupported calculation strategy")
            };

            return service;
        }
    }
}
