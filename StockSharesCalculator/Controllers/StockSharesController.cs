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
    private readonly IStockCalculationServiceFIFO _stockCalculationServiceFIFO;

    public StockSharesController(
        IStockTransactionsService stockTransactionsService,
        IStockCalculationServiceFIFO stockCalculationServiceFIFO)
    {
        _stockTransactionsService = stockTransactionsService;
        _stockCalculationServiceFIFO = stockCalculationServiceFIFO;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CalculateResult(ShareSaleViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View("Result", model);
        }

        if (model.NumberOfShares <= 0)
        {
            return View("Error", new ErrorViewModel
            {
                ErrorMessage = "The number of shares must be greater than zero."
            });
        }

        if (model.PricePerShare <= 0)
        {
            return View("Error", new ErrorViewModel
            {
                ErrorMessage = "The sale price per share must be greater than zero."
            });
        }     

        try
        {
            IEnumerable<StockTransaction> transactions = await _stockTransactionsService.GetAllStockTransactionsAsync();

            CalculationResultFIFO result = _stockCalculationServiceFIFO.CalculateResult(
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
            return View("Error", new ErrorViewModel { ErrorMessage = ex.Message });
        }
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { });
    }
}
