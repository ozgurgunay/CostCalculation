using CostCalculation.Areas.Admin.Services;
using CostCalculation.Areas.Admin.Services.IServices;
using CostCalculation.Data;
using CostCalculation.Extensions;
using CostCalculation.OptionsModel;
using CostCalculation.Repositories;
using CostCalculation.Repositories.Interfaces;
using CostCalculation.Services;
using CostCalculation.Services.IServices;
using Hangfire;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);


//Send email
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));

//Project Dependencies
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IFreightRepository, FreightRepository>();
builder.Services.AddScoped<IExchangeRateRepository, ExchangeRateRepository>();

//Services Dependencies
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICurrencyService, CurrencyService>();
builder.Services.AddScoped<IMemberService, MemberService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IUserService, UserService>();
//IHttpContextAccessor 
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<Context>(options => options.UseSqlServer(
builder.Configuration.GetConnectionString("ContentCreatorConnection")));

//Hangfire for job
builder.Services.AddHangfire(options => options
    .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
    .UseSqlServerStorage(builder.Configuration.GetConnectionString("ContentCreatorConnection")));

builder.Services.AddHangfireServer();


//Add picture and File 
builder.Services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Directory.GetCurrentDirectory()));

//extensions -> StartupExtensions
builder.Services.AddIdentityExtension();

builder.Services.ConfigureApplicationCookie(opt =>
{
    var cookieBuilder = new CookieBuilder();
    cookieBuilder.Name = "IdentityAppCookie";
    opt.LoginPath = new PathString("/Home/SignIn");
    opt.LogoutPath = new PathString("/Member/Logout");
    opt.AccessDeniedPath = new PathString("/Member/AccessDenied");
    opt.Cookie = cookieBuilder;
    opt.ExpireTimeSpan = TimeSpan.FromDays(15);
    opt.SlidingExpiration = true;
});


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

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
