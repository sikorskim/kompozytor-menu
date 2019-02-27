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
    public class PackageController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PackageController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: UnitOfMeasures
        public async Task<IActionResult> Index()
        {            
            return View(await _context.Package.ToListAsync());            
        }

        // GET: UnitOfMeasures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Package = await _context.Package
                .SingleOrDefaultAsync(m => m.Id == id);
            if (Package == null)
            {
                return NotFound();
            }

            return View(Package);
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
        public async Task<IActionResult> Create([Bind("Id,Name,Price")] Package Package)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Package);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Package);
        }

        // GET: UnitOfMeasures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Package = await _context.Package.SingleOrDefaultAsync(m => m.Id == id);
            if (Package == null)
            {
                return NotFound();
            }
            return View(Package);
        }

        // POST: UnitOfMeasures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price")] Package Package)
        {
            if (id != Package.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Package);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PackageExists(Package.Id))
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
            return View(Package);
        }

        // GET: UnitOfMeasures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Package = await _context.Package
                .SingleOrDefaultAsync(m => m.Id == id);
            if (Package == null)
            {
                return NotFound();
            }

            return View(Package);
        }

        // POST: UnitOfMeasures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Package = await _context.Package.SingleOrDefaultAsync(m => m.Id == id);
            _context.Package.Remove(Package);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PackageExists(int id)
        {
            return _context.Package.Any(e => e.Id == id);
        }
    }
}
