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
    public class HomeControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;
        private readonly Mock<UserManager<ApplicationUser>> _mockUserManager;

        public HomeControllerTests(WebApplicationFactory<Program> factory)
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
        public async Task Index_ShowsTheWelcomePage()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("/");
            var html = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();
            Assert.Contains("Welcome", html);
        }
    }
}
