using Microsoft.AspNetCore.Mvc;
using PatiKopru.Models;
using System.Diagnostics;

namespace PatiKopru.Controllers
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
            var userAd = HttpContext.Session.GetString("Ad");
            if (!string.IsNullOrEmpty(userAd))
            {
                ViewBag.WelcomeMessage = $"Hoş geldiniz, {userAd}!";
            }
            return View();
        }
        public IActionResult InfoAnimals()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult ContactUs()
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
