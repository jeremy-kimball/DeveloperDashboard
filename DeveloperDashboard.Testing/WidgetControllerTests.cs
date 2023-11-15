using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;

namespace DeveloperDashboard.Testing
{
    public class WidgetControllerTests
    {
        private readonly WebApplicationFactory<Program> _factory;

        public WidgetControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public void Test1()
        {

        }
    }
}
