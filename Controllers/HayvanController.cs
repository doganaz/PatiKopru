using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatiKopru.Models;
using System;

namespace PatiKopru.Controllers
{
    public class HayvanController : Controller
    {
        private readonly PatiDbContext _context;

        public HayvanController()
        {
            _context = new PatiDbContext();
        }

        public IActionResult Index()
        {
            var lst = _context.Hayvanlar.Include(h => h.Sahip).ToList();
            ViewBag.IsAuthenticated = !string.IsNullOrEmpty(HttpContext.Session.GetString("Email"));
            return View(lst);
        }

        [HttpGet]
        public IActionResult AddHayvan()
        {
            var email = HttpContext.Session.GetString("Email");
            if (string.IsNullOrEmpty(email))
            {
                TempData["ErrorMessage"] = "Hayvan eklemek için giriş yapmalısınız.";
                return RedirectToAction("Index");
            }

            ViewBag.Users = _context.Users.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult AddHayvan(Hayvan hayvan, bool MyAnimal)
        {
            var email = HttpContext.Session.GetString("Email");
            if (email == null)
            {
                TempData["ErrorMessage"] = "Oturum süresi doldu. Lütfen tekrar giriş yapın.";
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {
                if (MyAnimal)
                {
                    var currentUser = _context.Users.FirstOrDefault(u => u.Email == email);
                    if (currentUser != null)
                    {
                        hayvan.Sahip = currentUser; // Sahip alanı mevcut kullanıcıya atanıyor
                    }
                }

                _context.Hayvanlar.Add(hayvan);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Users = _context.Users.ToList();
            return View(hayvan);
        }

        [HttpPost]
        public IActionResult Sahiplen(int hayvanId)
        {
            var email = HttpContext.Session.GetString("Email");
            if (string.IsNullOrEmpty(email))
            {
                TempData["ErrorMessage"] = "Giriş yapmalısınız.";
                return Json(new { success = false });
            }

            var currentUser = _context.Users.FirstOrDefault(u => u.Email == email);
            if (currentUser == null)
            {
                TempData["ErrorMessage"] = "Geçersiz kullanıcı.";
                return Json(new { success = false });
            }

            var hayvan = _context.Hayvanlar.FirstOrDefault(h => h.Hayvanid == hayvanId);
            if (hayvan == null)
            {
                TempData["ErrorMessage"] = "Hayvan bulunamadı.";
                return Json(new { success = false });
            }

            hayvan.SahipId = currentUser.Userid;
            _context.SaveChanges();

            return Json(new { success = true });
        }
        public IActionResult MyHayvanlar()
        {
            var email = HttpContext.Session.GetString("Email");
            if (string.IsNullOrEmpty(email))
            {
                TempData["ErrorMessage"] = "Giriş yapmalısınız.";
                return RedirectToAction("Index", "Home");
            }

            var currentUser = _context.Users.FirstOrDefault(u => u.Email == email);
            if (currentUser == null)
            {
                TempData["ErrorMessage"] = "Geçersiz kullanıcı.";
                return RedirectToAction("Index", "Home");
            }

            var myHayvanlar = _context.Hayvanlar.Where(h => h.SahipId == currentUser.Userid).ToList();
            return View(myHayvanlar);
        }
    }
}
