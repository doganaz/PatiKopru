using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatiKopru.Models;

namespace PatiKopru.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddUser(User user)
        {
            if (user != null)
            {
                using (var ctx = new PatiDbContext())
                {
                    ctx.Users.Add(user);
                    ctx.SaveChanges();
                }
            }
            return RedirectToAction("Index","Home");
            
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            if(user != null)
            {
                using(var ctx = new PatiDbContext())
                {
                    var loggedInUser = ctx.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);
                    if (loggedInUser != null)
                    {
                        HttpContext.Session.SetString("Email", loggedInUser.Email);
                        HttpContext.Session.SetString("Ad", loggedInUser.Ad); // Username bilgisini de ekleyelim.
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Geçersiz email veya şifre");
                    }
                }  
            }
            return View(user);
        }

        // Çıkış yapma işlemi
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
        [HttpGet]
        public IActionResult ChangePassword() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var currentUser = GetCurrentLoggedInUser();

                if (currentUser != null && currentUser.Password == model.CurrentPassword)
                {
                    currentUser.Password = model.NewPassword;

                    using (var ctx = new PatiDbContext())
                    {
                        ctx.Entry(currentUser).State = EntityState.Modified;
                        ctx.SaveChanges();
                    }

                    TempData["SuccessMessage"] = "Şifreniz başarıyla değiştirildi.";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("CurrentPassword", "Mevcut şifrenizi yanlış girdiniz.");
                }
            }

            return View(model);
        }


        private User GetCurrentLoggedInUser()
        {
            var email = HttpContext.Session.GetString("Email");
            if (email != null)
            {
                using (var ctx = new PatiDbContext())
                {
                    return ctx.Users.FirstOrDefault(u => u.Email == email);
                }
            }
            return null;
        }

    }
}
