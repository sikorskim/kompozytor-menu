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
    public class MealTypeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MealTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UnitOfMeasures
        public async Task<IActionResult> Index()
        {
            return View(await _context.MealType.ToListAsync());
        }

        // GET: UnitOfMeasures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mealType = await _context.MealType
                .SingleOrDefaultAsync(m => m.Id == id);
            if (mealType == null)
            {
                return NotFound();
            }

            return View(mealType);
        }

        // GET: UnitOfMeasures/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UnitOfMeasures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] MealType mealType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mealType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mealType);
        }

        // GET: UnitOfMeasures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mealType = await _context.MealType.SingleOrDefaultAsync(m => m.Id == id);
            if (mealType == null)
            {
                return NotFound();
            }
            return View(mealType);
        }

        // POST: UnitOfMeasures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] MealType mealType)
        {
            if (id != mealType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mealType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MealTypeExists(mealType.Id))
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
            return View(mealType);
        }

        // GET: UnitOfMeasures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mealType = await _context.MealType
                .SingleOrDefaultAsync(m => m.Id == id);
            if (mealType == null)
            {
                return NotFound();
            }

            return View(mealType);
        }

        // POST: UnitOfMeasures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mealType = await _context.MealType.SingleOrDefaultAsync(m => m.Id == id);
            _context.MealType.Remove(mealType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MealTypeExists(int id)
        {
            return _context.MealType.Any(e => e.Id == id);
        }
    }
}
