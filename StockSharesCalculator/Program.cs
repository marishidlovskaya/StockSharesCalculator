using StockSharesCalculator.Environment.Repositories;
using StockSharesCalculator.Environment.Interfaces;
using StockSharesCalculator.Application.Interfaces;
using StockSharesCalculator.Application.Services;
using StockSharesCalculator.Web.Interfaces;
using StockSharesCalculator.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<IStockTransactionRepository, StockTransactionRepository>();
builder.Services.AddScoped<IStockTransactionsService, StockTransactionsService>();
builder.Services.AddScoped<IStockCalculationServiceFactory, StockCalculationServiceFactory>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=StockShares}/{action=Index}/{id?}");

app.Run();
