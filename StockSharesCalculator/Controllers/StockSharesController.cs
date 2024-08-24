using Microsoft.AspNetCore.Mvc;
using StockSharesCalculator.Application;
using StockSharesCalculator.Application.Interfaces;
using StockSharesCalculator.Environment.Entities;
using StockSharesCalculator.Models;
using StockSharesCalculator.Web.Models;

namespace StockSharesCalculator.Controllers;
public class StockSharesController : Controller
{
    private readonly IStockTransactionsService _stockTransactionsService;
    private readonly IStockCalculationService _stockCalculationService;

    public StockSharesController(
        IStockTransactionsService stockTransactionsService,
        IStockCalculationService stockCalculationService)
    {
        _stockTransactionsService = stockTransactionsService;
        _stockCalculationService = stockCalculationService;
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

            CalculationResult result = _stockCalculationService.CalculateResult(
                transactions, model.NumberOfShares, model.PricePerShare);

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
