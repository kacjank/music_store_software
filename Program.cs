using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sklep_muzyczny.Data;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Sklep_muzycznyContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Sklep_muzycznyContext") ?? throw new InvalidOperationException("Connection string 'Sklep_muzycznyContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();
var cultureInfor = new CultureInfo("en-US");
cultureInfor.NumberFormat.CurrencyGroupSeparator= " ";
cultureInfor.NumberFormat.CurrencyDecimalSeparator= ",";
cultureInfor.NumberFormat.CurrencyPositivePattern = 3;
cultureInfor.NumberFormat.CurrencySymbol = "zł";
CultureInfo.DefaultThreadCurrentCulture = cultureInfor;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfor;

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
