using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using DeveloperDashboard.Controllers;
using DeveloperDashboard.DataAccess;
using DeveloperDashboard.Models;

namespace DeveloperDashboard.Testing
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureServices(services =>
                    {
                        services.AddDbContext<DeveloperDashboardContext>(options =>
                             options.UseInMemoryDatabase("TestDatabase"));
                        services.AddControllersWithViews()
                            .AddApplicationPart(typeof(HomeController).Assembly);
                        services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                            .AddEntityFrameworkStores<DeveloperDashboardContext>();

                    });

                    webBuilder.Configure(app =>
                    {
                        app.UseRouting();
                        app.UseAuthentication();
                        app.UseAuthorization();
                        app.UseEndpoints(endpoints =>
                        {
                            endpoints.MapControllerRoute(
                                name: "default",
                                pattern: "{controller=Home}/{action=Index}/{id?}");
                        });
                    });
                });
    }
}
