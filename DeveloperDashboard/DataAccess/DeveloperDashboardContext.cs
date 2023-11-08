using Microsoft.EntityFrameworkCore;
using DeveloperDashboard.Models;
using System.Collections.Generic;

namespace DeveloperDashboard.DataAccess
{
    public class DeveloperDashboardContext : DbContext
    {
        public DbSet<Dashboard> Dashboards { get; set; }
        public DbSet<Widget> Widgets { get; set; }

        public DeveloperDashboardContext(DbContextOptions<DeveloperDashboardContext> options) : base(options)
        {

        }
    }
}
