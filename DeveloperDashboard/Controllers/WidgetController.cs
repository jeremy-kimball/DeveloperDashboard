using DeveloperDashboard.Services;
using Microsoft.AspNetCore.Mvc;

namespace DeveloperDashboard.Controllers
{
    public class WidgetController : Controller
    {
        private readonly IUrlShortenerApiService _urlShortenerApiService;
        private readonly IWeatherApiService _weatherApiService;

        public WidgetController(IUrlShortenerApiService urlShortenerApiService, IWeatherApiService weatherApiService)
        {
            _urlShortenerApiService = urlShortenerApiService;
            _weatherApiService = weatherApiService;
        }

        [HttpPost]
        public async Task<ActionResult> ShortenLink(string link, string customName)
        {
            var shortenedLink = await _urlShortenerApiService.GetShortLink(link, customName);
            ViewBag.StringForPartial = shortenedLink;
            return PartialView("_ShortenedLinkPartial");
        }

        [HttpPost]
        public async Task<ActionResult> GetWeather(string location)
        {
            var weather = await _weatherApiService.GetWeather(location);
            return PartialView("_WeatherResult", weather);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
