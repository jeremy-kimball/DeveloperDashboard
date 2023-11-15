using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;

namespace DeveloperDashboard.Testing
{
    public class DashboardControllerTests
    {
        private readonly WebApplicationFactory<Program> _factory;

        public DashboardControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public void Test1()
        {

        }
    }
}
