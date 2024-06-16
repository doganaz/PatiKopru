using Microsoft.AspNetCore.Mvc;
using PatiKopru.Models;

namespace PatiKopru.Controllers
{
    public class VeterinerController : Controller
    {
        public IActionResult Index()
        {
            using(var ctx = new PatiDbContext())
            {
                var lst = ctx.Veterinerler.ToList();
                return View(lst);
            }
        }
        [HttpGet]
        public IActionResult AddVet()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddVet(Veteriner veteriner)
        {
            if (veteriner != null)
            {
                using (var ctx = new PatiDbContext())
                {
                    ctx.Veterinerler.Add(veteriner);
                    ctx.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
    }
}
