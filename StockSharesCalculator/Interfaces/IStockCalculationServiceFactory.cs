using StockSharesCalculator.Application.Interfaces;
using StockSharesCalculator.Web.Enums;

namespace StockSharesCalculator.Web.Interfaces
{
    public interface IStockCalculationServiceFactory
    {
        IStockCalculationService GetCalculatorService(CalculationStrategy strategy);
    }
}
