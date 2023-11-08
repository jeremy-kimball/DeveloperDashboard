using DeveloperDashboard.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace DeveloperDashboard.Controllers
{
    public class DashboardController : Controller
    {
        private readonly DeveloperDashboardContext _context;

        public DashboardController(DeveloperDashboardContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult New()
        {
            return View();
        }
    }
}
