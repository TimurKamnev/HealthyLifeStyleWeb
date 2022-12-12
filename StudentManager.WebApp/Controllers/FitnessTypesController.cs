using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fitness.Infrastracture;
using StudentManager.Backend.Entities;

namespace StudentManager.WebApp.Controllers
{
    public class FitnessTypesController : Controller
    {
        private readonly AppDbContext _context;

        public FitnessTypesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: FitnessTypes

        public async Task<IActionResult> Index()
        {
            return View(await _context.FitnessType.ToListAsync());
        }

        // GET: FitnessTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FitnessType == null)
            {
                return NotFound();
            }

            var fitnessType = await _context.FitnessType
                .FirstOrDefaultAsync(m => m.FitnessProgramId == id);
            if (fitnessType == null)
            {
                return NotFound();
            }

            return View(fitnessType);
        }

        // GET: FitnessTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FitnessTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,FitnessProgramId")] FitnessType fitnessType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fitnessType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fitnessType);
        }

        // GET: FitnessTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FitnessType == null)
            {
                return NotFound();
            }

            var fitnessType = await _context.FitnessType.FindAsync(id);
            if (fitnessType == null)
            {
                return NotFound();
            }
            return View(fitnessType);
        }

        // POST: FitnessTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,FitnessProgramId")] FitnessType fitnessType)
        {
            if (id != fitnessType.FitnessProgramId)
            {
                return NotFound();
            }

            if (id == fitnessType.Id)
            {
                try
                {
                    _context.Update(fitnessType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FitnessTypeExists(fitnessType.FitnessProgramId))
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
            return View(fitnessType);
        }

        // GET: FitnessTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FitnessType == null)
            {
                return NotFound();
            }

            var fitnessType = await _context.FitnessType
                .FirstOrDefaultAsync(m => m.FitnessProgramId == id);
            if (fitnessType == null)
            {
                return NotFound();
            }

            return View(fitnessType);
        }

        // POST: FitnessTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FitnessType == null)
            {
                return Problem("Entity set 'AppDbContext.FitnessType'  is null.");
            }
            var fitnessType = await _context.FitnessType.FindAsync(id);
            if (fitnessType != null)
            {
                _context.FitnessType.Remove(fitnessType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FitnessTypeExists(int id)
        {
          return _context.FitnessType.Any(e => e.FitnessProgramId == id);
        }
    }
}
