using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using kompozytor_menu;
using kompozytor_menu.Models;
using kompozytor_menu.Data;
using Microsoft.EntityFrameworkCore;

namespace kompozytor_menu.Controllers
{
    public class MealController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MealController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UnitOfMeasures
        public async Task<IActionResult> Index()
        {
            var meals = _context.Meal.Include(i=>i.Package).Include(i=>i.MealType);
            return View(await meals.ToListAsync());            
        }

        // GET: UnitOfMeasures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Meal = await _context.Meal
                .SingleOrDefaultAsync(m => m.Id == id);
            if (Meal == null)
            {
                return NotFound();
            }

            return View(Meal);
        }

        // GET: UnitOfMeasures/Create
        public IActionResult Create()
        {
            ViewData["MealTypeId"] = new SelectList (_context.MealType, "Id", "Name");
            ViewData["PackageId"] = new SelectList (_context.Package, "Id", "Name");

            return View();
        }

        // POST: UnitOfMeasures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,MealTypeId,PackageId")] Meal Meal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Meal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["MealTypeId"] = new SelectList (_context.MealType, "Id", "Name");
            ViewData["PackageId"] = new SelectList (_context.Package, "Id", "Name");

            return View(Meal);
        }

        // GET: UnitOfMeasures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Meal = await _context.Meal.SingleOrDefaultAsync(m => m.Id == id);
            if (Meal == null)
            {
                return NotFound();
            }

            ViewData["MealTypeId"] = new SelectList (_context.MealType, "Id", "Name");
            ViewData["PackageId"] = new SelectList (_context.Package, "Id", "Name");

            return View(Meal);
        }

        // POST: UnitOfMeasures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,MealTypeId,PackageId")] Meal Meal)
        {
            if (id != Meal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Meal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MealExists(Meal.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["MealTypeId"] = new SelectList (_context.MealType, "Id", "Name");
            ViewData["PackageId"] = new SelectList (_context.Package, "Id", "Name");

            return View(Meal);
        }

        // GET: UnitOfMeasures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Meal = await _context.Meal
                .SingleOrDefaultAsync(m => m.Id == id);
            if (Meal == null)
            {
                return NotFound();
            }

            return View(Meal);
        }

        // POST: UnitOfMeasures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Meal = await _context.Meal.SingleOrDefaultAsync(m => m.Id == id);
            _context.Meal.Remove(Meal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MealExists(int id)
        {
            return _context.Meal.Any(e => e.Id == id);
        }
    }
}
