using Microsoft.EntityFrameworkCore;
using DeveloperDashboard.DataAccess;
using DeveloperDashboard.Services;
using Microsoft.AspNetCore.Identity;
using DeveloperDashboard.Models;

var builder = WebApplication.CreateBuilder(args);
string DEVELOPERDASHBOARD_DBCONNECTIONSTRING = $"Server={Environment.GetEnvironmentVariable("PGHOST")};Database={Environment.GetEnvironmentVariable("PGDATABASE")};Port={Environment.GetEnvironmentVariable("PGPORT")};Username={Environment.GetEnvironmentVariable("PGUSER")};Password={Environment.GetEnvironmentVariable("PGPASSWORD")}";

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IUrlShortenerApiService, UrlShortenerApiService>();
builder.Services.AddSingleton<IWeatherApiService, WeatherApiService>();
builder.Services.AddDbContext<DeveloperDashboardContext>(
    options =>
        options
            .UseNpgsql(DEVELOPERDASHBOARD_DBCONNECTIONSTRING
                    ?? throw new InvalidOperationException(
                            "Connection String 'DevDashDBNotFound' not found"
                            )
                    )
                    .UseSnakeCaseNamingConvention()
                    );

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<DeveloperDashboardContext>();
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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
