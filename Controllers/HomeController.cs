using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using kompozytor_menu.Models;
using kompozytor_menu.Data;
using kompozytor_menu.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace kompozytor_menu.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

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

        public async Task<IActionResult> Menu()
        {
            ViewData["Soups0Price"] = _context.Package.Single(p=>p.Id==1).Price.ToString("0.00");
            ViewData["Soups1Price"] = _context.Package.Single(p=>p.Id==2).Price.ToString("0.00");
            ViewData["Soups2Price"] = _context.Package.Single(p=>p.Id==3).Price.ToString("0.00");

            var allMeals = _context.Meal;

            return View(await allMeals.ToListAsync());
        }

        public IActionResult Menu2()
        {
            ViewData["Soups0Price"] = _context.Package.Single(p=>p.Id==1).Price.ToString("0.00");
            ViewData["Soups1Price"] = _context.Package.Single(p=>p.Id==2).Price.ToString("0.00");
            ViewData["Soups2Price"] = _context.Package.Single(p=>p.Id==3).Price.ToString("0.00");

            var allMeals = _context.Meal;
            List<MyMenuItemViewModel> allMenuItems = new List<MyMenuItemViewModel>();

            foreach(Meal m in allMeals)
            {
                MyMenuItemViewModel item = new MyMenuItemViewModel(m.Id, m.Name, m.PackageId, m.MealTypeId);
                allMenuItems.Add(item);
            }    

            MyMenuViewModel myMenuViewModel = new MyMenuViewModel(allMenuItems);

            return View(myMenuViewModel);
        }
    }
}