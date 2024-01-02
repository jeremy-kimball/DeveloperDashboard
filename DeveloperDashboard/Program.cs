using Microsoft.EntityFrameworkCore;
using DeveloperDashboard.DataAccess;
using DeveloperDashboard.Services;
using Microsoft.AspNetCore.Identity;
using DeveloperDashboard.Models;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IUrlShortenerApiService, UrlShortenerApiService>();
builder.Services.AddSingleton<IWeatherApiService, WeatherApiService>();

var postgresConnectionString = new NpgsqlConnectionStringBuilder
{
    Host = Environment.GetEnvironmentVariable("PGHOST") ?? throw new InvalidOperationException("Database host (PGHOST) not found."),
    Database = Environment.GetEnvironmentVariable("PGDATABASE") ?? throw new InvalidOperationException("Database name (PGDATABASE) not found."),
    Port = int.Parse(Environment.GetEnvironmentVariable("PGPORT") ?? throw new InvalidOperationException("Database port (PGPORT) not found.")),
    Username = Environment.GetEnvironmentVariable("PGUSER") ?? throw new InvalidOperationException("Database username (PGUSER) not found."),
    Password = Environment.GetEnvironmentVariable("PGPASSWORD") ?? throw new InvalidOperationException("Database password (PGPASSWORD) not found.")
}.ConnectionString;

builder.Services.AddDbContext<DeveloperDashboardContext>(
    options => options.UseNpgsql(postgresConnectionString).UseSnakeCaseNamingConvention()
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
