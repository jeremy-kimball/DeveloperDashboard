using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperDashboard.DataAccess;
using DeveloperDashboard.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace DeveloperDashboard.Testing
{
    public class DashboardControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly Mock<UserManager<ApplicationUser>> _mockUserManager;

        public DashboardControllerTests(WebApplicationFactory<Program> factory)
        {
            _mockUserManager = new Mock<UserManager<ApplicationUser>>(
            new Mock<IUserStore<ApplicationUser>>().Object,
            null, null, null, null, null, null, null, null);
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
