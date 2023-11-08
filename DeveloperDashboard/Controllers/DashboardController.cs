using Microsoft.AspNetCore.Mvc;

namespace DeveloperDashboard.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
