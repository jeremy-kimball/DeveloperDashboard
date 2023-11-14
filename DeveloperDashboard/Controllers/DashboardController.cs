using DeveloperDashboard.DataAccess;
using Microsoft.AspNetCore.Mvc;
using DeveloperDashboard.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

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
            var dashboards = _context.Dashboards.ToList();
            return View(dashboards);
        }

        [Authorize]
        public IActionResult New()
        {
            var widgetList = _context.Widgets.ToList();
            ViewBag.widgetBag = widgetList;

            return View();
        }

        [Route("/Dashboard/{id:int}")]
        public IActionResult Show(int id)
        {
            var dashboard = _context.Dashboards.Include(d => d.Widgets).Where(d => d.Id == id).First();
            return View(dashboard);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(string name, int[] selectedWidgetIds, string userId)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var selectedWidgets = _context.Widgets
                .Where(widget => selectedWidgetIds.Contains(widget.Id))
                .ToList();
            var user = _context.Users.Find(userId);
            var dashboard = new Dashboard
            {
                Name = name,
                Widgets = selectedWidgets,
                User = user
            };

            _context.Dashboards.Add(dashboard);
            _context.SaveChanges();

            return Redirect($"/Dashboard/{dashboard.Id}");
        }

        [Route("/Dashboard/{id:int}/Edit")]
        public IActionResult Edit(int id)
        {
            var dashboard = _context.Dashboards.Include(d => d.Widgets).First(d => d.Id == id);
            var widgetList = _context.Widgets.ToList();
            var dashboardWidgets = dashboard.Widgets.Select(w => w.Id).ToList();

            ViewBag.widgetBag = widgetList;
            ViewBag.dashboardWidgetIds = dashboardWidgets;

            return View(dashboard);
        }

        [HttpPost]
        [Route("/Dashboard/{id:int}/Update")]
        public IActionResult Update(int id, Dashboard dashboard, int[] selectedWidgetIds)
        {
            var dashboardToUpdate = _context.Dashboards.Include(d => d.Widgets).First(d => d.Id == id);
            dashboardToUpdate.Name = dashboard.Name;
            dashboardToUpdate.Widgets.Clear();
            foreach(var widgetId in selectedWidgetIds)
            {
                dashboardToUpdate.Widgets.Add(_context.Widgets.Find(widgetId));
            }
            _context.Dashboards.Update(dashboardToUpdate);
            _context.SaveChanges();

            return Redirect($"/Dashboard/{dashboardToUpdate.Id}");
        }

        [HttpPost]
        [Route("/Dashboard/{id:int}/Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var dashboardToDelete = _context.Dashboards.Include(d => d.Widgets).First(d => d.Id == id);
            _context.Dashboards.Remove(dashboardToDelete);
            _context.SaveChanges();

            return Redirect($"/Dashboard");
        }
    }
}
