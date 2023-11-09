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
            var widgetList = _context.Widgets;
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
        public async Task<IActionResult> Create(string name, int[] selectedWidgetIds)
        {
            if (selectedWidgetIds.Length == 0)
            {
                ModelState.AddModelError("", "You must select at least one widget.");
            }
            if (string.IsNullOrWhiteSpace(name))
            {
                ModelState.AddModelError("Name", "The Name field is required.");
            }

            if (!ModelState.IsValid)
            {
                ViewBag.widgetBag = new SelectList(_context.Widgets, "Id", "Name");
                return View();
            }

            var selectedWidgets = _context.Widgets
                .Where(widget => selectedWidgetIds.Contains(widget.Id))
                .ToList();

            var dashboard = new Dashboard
            {
                Name = name,
                Widgets = selectedWidgets
            };

            _context.Dashboards.Add(dashboard);
            await _context.SaveChangesAsync();

            return Redirect($"/Dashboard/{dashboard.Id}");
        }
    }
}
