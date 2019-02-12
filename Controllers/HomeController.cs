using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using kompozytor_menu.Models;

namespace kompozytor_menu.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
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

        public IActionResult Menu()
        {
            ViewData["Soups0"] = null;
            ViewData["Soups1"] = null;
            ViewData["Soups2"] = null;

            ViewData["Meats0"] = null;
            ViewData["Meats1"] = null;
            ViewData["Meats2"] = null;

            ViewData["AddOns"] = null;

            return View();
        }
    }
}
