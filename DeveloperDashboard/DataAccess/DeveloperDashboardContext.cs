﻿using Microsoft.EntityFrameworkCore;
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
                    Name = "Url Shortener",
                    Content = "_UrlShortener",
                    Width = 2,
                    Height = 2
                },
                new Widget
                {
                    Id = 2,
                    Name = "Google Search",
                    Content = "_GoogleSearch",
                    Width = 2,
                    Height = 2
                },
                new Widget
                {
                    Id = 3,
                    Name = "Weather",
                    Content = "_Weather",
                    Width = 2,
                    Height = 2
                }
            // You can add more widgets here
            );
        }
    }
}
