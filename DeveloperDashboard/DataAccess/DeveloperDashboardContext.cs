using Microsoft.EntityFrameworkCore;
using DeveloperDashboard.Models;
using System.Collections.Generic;

namespace DeveloperDashboard.DataAccess
{
    public class DeveloperDashboardContext : DbContext
    {
        public DeveloperDashboardContext(DbContextOptions<DeveloperDashboardContext> options) : base(options)
        {

        }
    }
}
