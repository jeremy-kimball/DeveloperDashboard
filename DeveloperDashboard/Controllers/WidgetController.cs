using DeveloperDashboard.Services;
using Microsoft.AspNetCore.Mvc;

namespace DeveloperDashboard.Controllers
{
    public class WidgetController : Controller
    {
        private readonly IUrlShortenerApiService _urlShortenerApiService;

        public WidgetController(IUrlShortenerApiService urlShortenerApiService)
        {
            _urlShortenerApiService = urlShortenerApiService;
        }

        [HttpPost]
        public async Task<ActionResult> ShortenLink(string link, string customName)
        {
            var shortenedLink = await _urlShortenerApiService.GetShortLink(link, customName);
            ViewBag.StringForPartial = shortenedLink;
            return PartialView("_ShortenedLinkPartial");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
