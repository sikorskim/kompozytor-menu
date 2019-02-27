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
    public class MyMenuController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MyMenuController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UnitOfMeasures
        public async Task<IActionResult> Index()
        {
            //var MyMenus = _context.MyMenu.Include(i=>i.Package).Include(i=>i.MealType);
            return View(await _context.MyMenu.ToListAsync());            
        }

        // GET: UnitOfMeasures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var MyMenu = await _context.MyMenu
                .SingleOrDefaultAsync(m => m.Id == id);
            if (MyMenu == null)
            {
                return NotFound();
            }

            return View(MyMenu);
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
        public async Task<IActionResult> Create([Bind("Id,Name,MealTypeId,PackageId")] MyMenu MyMenu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(MyMenu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["MealTypeId"] = new SelectList (_context.MealType, "Id", "Name");
            ViewData["PackageId"] = new SelectList (_context.Package, "Id", "Name");

            return View(MyMenu);
        }

        // GET: UnitOfMeasures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var MyMenu = await _context.MyMenu.SingleOrDefaultAsync(m => m.Id == id);
            if (MyMenu == null)
            {
                return NotFound();
            }

            ViewData["MealTypeId"] = new SelectList (_context.MealType, "Id", "Name");
            ViewData["PackageId"] = new SelectList (_context.Package, "Id", "Name");

            return View(MyMenu);
        }

        // POST: UnitOfMeasures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,MealTypeId,PackageId")] MyMenu MyMenu)
        {
            if (id != MyMenu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(MyMenu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MyMenuExists(MyMenu.Id))
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

            return View(MyMenu);
        }

        // GET: UnitOfMeasures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var MyMenu = await _context.MyMenu
                .SingleOrDefaultAsync(m => m.Id == id);
            if (MyMenu == null)
            {
                return NotFound();
            }

            return View(MyMenu);
        }

        // POST: UnitOfMeasures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var MyMenu = await _context.MyMenu.SingleOrDefaultAsync(m => m.Id == id);
            _context.MyMenu.Remove(MyMenu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MyMenuExists(int id)
        {
            return _context.MyMenu.Any(e => e.Id == id);
        }
    }
}
