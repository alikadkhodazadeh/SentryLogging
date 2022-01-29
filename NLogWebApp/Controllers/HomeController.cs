using Microsoft.AspNetCore.Mvc;
using NLogWebApp.Models;
using System.Diagnostics;

namespace NLogWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            while (true)
            {
                _logger.LogTrace("NLog", "LogTrace");
                _logger.LogDebug("NLog", "LogDebug");
                _logger.LogError("NLog", "LogError");
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}