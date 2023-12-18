using CostCalculation.Data;
using CostCalculation.Repositories;
using CostCalculation.Repositories.Interfaces;
using CostCalculation.Services;
using CostCalculation.Services.IServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Project Dependencies
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IFreightRepository, FreightRepository>();
builder.Services.AddScoped<IExchangeRateRepository, ExchangeRateRepository>();

//Services Dependencies
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICurrencyService, CurrencyService>();
//IHttpContextAccessor 
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<Context>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("ContentCreatorConnection")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
