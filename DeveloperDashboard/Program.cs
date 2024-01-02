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
    Host = builder.Configuration["PGHOST"] ?? throw new InvalidOperationException("Database host (PGHOST) not found."),
    Database = builder.Configuration["PGDATABASE"] ?? throw new InvalidOperationException("Database name (PGDATABASE) not found."),
    Port = int.Parse(builder.Configuration["PGPORT"] ?? throw new InvalidOperationException("Database port (PGPORT) not found.")),
    Username = builder.Configuration["PGUSER"] ?? throw new InvalidOperationException("Database username (PGUSER) not found."),
    Password = builder.Configuration["PGPASSWORD"] ?? throw new InvalidOperationException("Database password (PGPASSWORD) not found.")
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
