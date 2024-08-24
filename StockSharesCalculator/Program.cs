using StockSharesCalculator.Environment.Repositories;
using StockSharesCalculator.Environment.Interfaces;
using StockSharesCalculator.Application.Interfaces;
using StockSharesCalculator.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register in-memory repository and services
builder.Services.AddSingleton<IStockTransactionRepository, InMemoryStockTransactionRepository>();
builder.Services.AddScoped<IStockTransactionsService, StockTransactionsService>();
builder.Services.AddScoped<IStockCalculationServiceFIFO, StockCalculationServiceFIFO>();


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
