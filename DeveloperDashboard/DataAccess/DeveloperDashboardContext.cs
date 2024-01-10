using Microsoft.EntityFrameworkCore;
using DeveloperDashboard.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace DeveloperDashboard.DataAccess
{
    public class DeveloperDashboardContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Dashboard> Dashboards { get; set; }
        public DbSet<Widget> Widgets { get; set; }

        public DeveloperDashboardContext(DbContextOptions<DeveloperDashboardContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Widget>().HasData(
                new Widget
                {
                    Id = 1,
                    Name = "Url_Shortener",
                    Content = "_UrlShortener",
                    W = 5,
                    H = 2,
                    Properties = "gs-no-resize=\"true\""
                },
                new Widget
                {
                    Id = 2,
                    Name = "Google_Search",
                    Content = "_GoogleSearch",
                    W = 8,
                    H = 1,
                    Properties = "gs-no-resize=\"true\""
                },
                new Widget
                {
                    Id = 3,
                    Name = "Weather",
                    Content = "_Weather",
                    W = 4,
                    H = 3,
                    Properties = "gs-no-resize=\"true\""
                }
            // You can add more widgets here
            );
        }
    }
}
