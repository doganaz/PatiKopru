using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatiKopru.Models;

namespace PatiKopru.Controllers
{
    public class DonationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult MakeDonation()
        {
            return View();
        }
        [HttpPost]
        public IActionResult MakeDonation(Donation model)
        { 
                var email = HttpContext.Session.GetString("Email");
                if (email != null)
                {
                    using(var ctx=new PatiDbContext())
                    {
                        var user=ctx.Users.FirstOrDefault(u => u.Email == email);
                            if (user != null)
                            {
                            model.UserId = user.Userid;
                            model.Date = DateTime.Now;
                            ctx.Donations.Add(model);
                            ctx.SaveChanges();
                            
                            return RedirectToAction("ThankYou");
                        }
                    }
                }
            
            return View(model);
        }

        public IActionResult ThankYou()
        {
            return View();
        }

        public IActionResult UserDonations()
        {
            var email = HttpContext.Session.GetString("Email");
            if (email != null)
            {
                using(var ctx=new PatiDbContext())
                {
                    var user = ctx.Users.Include(u => u.Donations).FirstOrDefault(u => u.Email == email);
                    if (user != null)
                    {
                    return View(user.Donations);
                    }
                } 
            }
            return RedirectToAction("Login", "User");
        }
    }
}
