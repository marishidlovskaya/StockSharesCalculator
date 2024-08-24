using Microsoft.AspNetCore.Mvc;
using StockSharesCalculator.Application;
using StockSharesCalculator.Application.Interfaces;
using StockSharesCalculator.Environment.Entities;
using StockSharesCalculator.Models;
using StockSharesCalculator.Web.Interfaces;
using StockSharesCalculator.Web.Models;

namespace StockSharesCalculator.Controllers;
public class StockSharesController : Controller
{
    private readonly IStockTransactionsService _stockTransactionsService;
    private readonly IStockCalculationServiceFactory _stockCalculationServiceFactory;

    public StockSharesController(
        IStockTransactionsService stockTransactionsService,
        IStockCalculationServiceFactory stockCalculationServiceFactory)
    {
        _stockTransactionsService = stockTransactionsService;
        _stockCalculationServiceFactory = stockCalculationServiceFactory;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CalculateResult(InputStockSaleViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View("Result", model);
        }

        try
        {
            IEnumerable<StockTransaction> transactions = await _stockTransactionsService.GetAllStockTransactionsAsync();

            IStockCalculationService stockCalculationService = _stockCalculationServiceFactory.GetCalculatorService(model.CalculationStrategy);

            CalculationResult result = stockCalculationService.CalculateResult(transactions, model.NumberOfShares, model.PricePerShare);

            CalculationResultViewModel resultModel = new()
            {
                RemainingShares = result.RemainingShares,
                CostBasisOfSoldShares = result.CostBasisOfSoldShares,
                CostBasisOfRemainingShares = result.CostBasisOfRemainingShares,
                Profit = result.Profit
            };

            return PartialView("Result", resultModel);
        }
        catch (Exception ex)
        {
            return PartialView("Error", new ErrorViewModel { ErrorMessage = ex.Message });
        }
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { });
    }
}
