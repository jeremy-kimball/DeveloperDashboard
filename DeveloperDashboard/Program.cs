using Microsoft.EntityFrameworkCore;
using DeveloperDashboard.DataAccess;
using DeveloperDashboard.Services;
using Microsoft.AspNetCore.Identity;
using DeveloperDashboard.Models;

string connectionString = $"Server={Environment.GetEnvironmentVariable("DATABASE_URL")};Database={Environment.GetEnvironmentVariable("POSTGRES_DB")};Port={Environment.GetEnvironmentVariable("PGPORT")};Username={Environment.GetEnvironmentVariable("POSTGRES_USER")};Password={Environment.GetEnvironmentVariable("POSTGRES_PASSWORD")}";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IUrlShortenerApiService, UrlShortenerApiService>();
builder.Services.AddSingleton<IWeatherApiService, WeatherApiService>();
builder.Services.AddDbContext<DeveloperDashboardContext>(
    options =>
        options
            .UseNpgsql(
                connectionString
                    ?? throw new InvalidOperationException(
                            "Connection String 'DevDashDBNotFound' not found"
                            )
                    )
                    .UseSnakeCaseNamingConvention()
                    );


builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<DeveloperDashboardContext>();
var app = builder.Build();
var scope = app.Services.CreateScope();
await DataHelper.ManageDataAsync(scope.ServiceProvider);
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
