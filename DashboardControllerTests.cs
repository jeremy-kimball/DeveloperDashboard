using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeveloperDashboard.DataAccess;
using DeveloperDashboard.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace DeveloperDashboard.Testing
{
    public class DashboardControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public DashboardControllerTests(WebApplicationFactory<Program> factory)
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

        //[Fact]
        //public async void Dashboard_Index_ShowsAllUsersDashboards()
        //{
            ////Arrange
            //var context = GetDbContext();
            //var client = _factory.CreateClient();

            //var response = await client.GetAsync("/albums/1");
            //var html = await response.Content.ReadAsStringAsync();

            //var store = new Mock<IUserStore<ApplicationUser>>();
            //var userManager = new UserManager<ApplicationUser>(
            //    store.Object, null, null, null, null, null, null, null, null);

            //var urlWidget = new Widget
            //{
            //    Id = 1,
            //    Name = "Url Shortener",
            //    Content = "_UrlShortener",
            //    Width = 2,
            //    Height = 2
            //};
            //var widgetList = new List<Widget>();
            //widgetList.Add(urlWidget);

            //var testUser = new ApplicationUser();

            //var dashboard = new Dashboard
            //{
            //    Id = 1,
            //    Name = "TestDash",
            //    Widgets = widgetList
            //};
            //testUser.Dashboards.Add(dashboard);

            //context.SaveChanges();

            //var creationResult = await userManager.CreateAsync(testUser);
            //if (!creationResult.Succeeded)
            //{
            //    throw new InvalidOperationException("Could not create test user in setup.");
            //}



            //response.EnsureSuccessStatusCode();
        //}

        [Fact]
        public async void Dashboard_Index_ShowsAllUsersDashboards()
        {
            var context = GetDbContext();
            var client = _factory.CreateClient();

            var store = new Mock<IUserStore<ApplicationUser>>();
            var userManager = new UserManager<ApplicationUser>(
                store.Object, null, null, null, null, null, null, null, null);

            var urlWidget = new Widget
            {
                Id = 1,
                Name = "Url Shortener",
                Content = "_UrlShortener",
                Width = 2,
                Height = 2
            };
            var widgetList = new List<Widget>();
            widgetList.Add(urlWidget);

            var testUser = new ApplicationUser();

            var dashboard = new Dashboard
            {
                Id = 1,
                User = testUser,
                Name = "TestDash",
                Widgets = widgetList
            };
            await userManager.CreateAsync(testUser);
            context.SaveChanges();

            var dashboards = context.Dashboards.Where(d => d.User.Id == testUser.Id).ToList();

            var response = await client.GetAsync("/Dashboard");
            var html = await response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode();
        }
    }
}
