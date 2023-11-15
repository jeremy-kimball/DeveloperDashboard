using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperDashboard.DataAccess;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;

namespace DeveloperDashboard.Testing
{
    public class WidgetControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public WidgetControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        private DeveloperDashboardContext GetDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<DeveloperDashboardContext>();
            optionsBuilder.UseInMemoryDatabase("TestDatabase");

            var context = new DeveloperDashboardContext(optionsBuilder.Options);
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            return context;
        }

        [Fact]
        public void Test1()
        {

        }
    }
}
