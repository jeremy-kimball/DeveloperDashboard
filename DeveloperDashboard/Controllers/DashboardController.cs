using DeveloperDashboard.DataAccess;
using Microsoft.AspNetCore.Mvc;
using DeveloperDashboard.Models;

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

        [Route("/Dashboard/{id:int}")]
        public IActionResult Show(int id)
        {
            var dashboard = _context.Dashboards.Find(id);
            return View(dashboard);
        }

        [HttpPost]
        public IActionResult Create(Dashboard dashboard)
        {
            return View();
        }
    }
}
