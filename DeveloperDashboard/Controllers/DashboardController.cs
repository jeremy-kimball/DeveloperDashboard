using DeveloperDashboard.DataAccess;
using Microsoft.AspNetCore.Mvc;
using DeveloperDashboard.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing.Template;
using System.Security.Cryptography;

namespace DeveloperDashboard.Controllers
{
    public class DashboardController : Controller
    {
        private readonly DeveloperDashboardContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public DashboardController(DeveloperDashboardContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        [Authorize]
        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(User);
            var dashboards = _context.Dashboards.Where(d => d.User.Id == userId).ToList();
            return View(dashboards);
        }

        [Authorize]
        public IActionResult New()
        {
            var widgetList = _context.Widgets.Where(w => w.Template == true).ToList();
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

            var widgetCopies = new List<Widget>();

            foreach(var widget in selectedWidgets)
            {
                var widgetCopy = new Widget()
                {
                    Template = false,
                    Name = widget.Name,
                    Content = widget.Content,
                    W = widget.W,
                    H = widget.H,
                    X = widget.X,
                    Y = widget.Y,
                    Properties = widget.Properties
                };

                widgetCopies.Add(widgetCopy);
            }

            var user = _context.Users.Find(userId);
            var dashboard = new Dashboard
            {
                Name = name,
                Widgets = widgetCopies,
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
        [Route("/Dashboard/{id:int}/Save")]
        public IActionResult Save(int id, string serializedData)
        {
            var positions = JsonConvert.DeserializeObject<List<PositionModel>>(serializedData);
            var dashboardToUpdate = _context.Dashboards.Include(d => d.Widgets).First(d => d.Id == id);
            foreach(var widget in dashboardToUpdate.Widgets)
            {
                foreach(var position in positions)
                {
                    if (position.Id == widget.Id)
                    {
                        widget.W = position.W;
                        widget.H = position.H;
                        widget.X = position.X;
                        widget.Y = position.Y;
                    }
                }
            }
            _context.Dashboards.Update(dashboardToUpdate);
            _context.SaveChanges();

            return Redirect($"/Dashboard/{id}");
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
