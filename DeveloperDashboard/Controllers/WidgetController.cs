using Microsoft.AspNetCore.Mvc;

namespace DeveloperDashboard.Controllers
{
    public class WidgetController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
