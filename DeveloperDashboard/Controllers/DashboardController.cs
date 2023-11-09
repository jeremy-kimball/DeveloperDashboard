using DeveloperDashboard.DataAccess;
using Microsoft.AspNetCore.Mvc;
using DeveloperDashboard.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
            List<Widget> widgetList = _context.Widgets.ToList();
            ViewBag.widgetBag = new SelectList(widgetList, "Id", "Name");
            return View();
        }

        [Route("/Dashboard/{id:int}")]
        public IActionResult Show(int id)
        {
            var dashboard = _context.Dashboards.Include(d => d.Widgets).Where(d => d.Id == id).First();
            return View(dashboard);
        }

        [HttpPost]
        public IActionResult Create(Dashboard dashboard)
        {
            if(ModelState.IsValid)
            {
                _context.Dashboards.Add(dashboard);
                _context.SaveChanges();
            }
            return Redirect($"/Dashboard/{dashboard.Id}");
        }
    }
}
