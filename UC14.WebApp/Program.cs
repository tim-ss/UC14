using Microsoft.AspNetCore.Localization;
using System.Globalization;
using UC14.WebApp.Models;
using UC14.WebApp.Models.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.AddControllersWithViews().AddViewLocalization();
builder.Services.AddScoped<IUnitsService, UnitsService>();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

var supportedCultures = new List<CultureInfo> {
    new CultureInfo("en-US"),
    new CultureInfo("uk-UA"),
    new CultureInfo("fr-FR"),
    new CultureInfo("pl-PL")
    };

app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("en-US"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures,
    
});

app.UseMiddleware<UnsupportedCultureMiddleware>(supportedCultures);
app.Run();
