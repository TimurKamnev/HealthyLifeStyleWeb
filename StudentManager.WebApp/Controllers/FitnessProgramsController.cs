using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fitness.Infrastracture;
using StudentManager.Backend.Entities;
using Microsoft.AspNetCore.Authorization;

namespace StudentManager.WebApp.Controllers
{

    public class FitnessProgramsController : Controller
    {
        private readonly AppDbContext _context;

        public FitnessProgramsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: FitnessPrograms
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.FitnessProgram.Include(f => f.FitnessType);
            return View(await appDbContext.ToListAsync());
        }

        // GET: FitnessPrograms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FitnessProgram == null)
            {
                return NotFound();
            }

            var fitnessProgram = await _context.FitnessProgram
                .Include(f => f.FitnessType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fitnessProgram == null)
            {
                return NotFound();
            }

            return View(fitnessProgram);
        }

        // GET: FitnessPrograms/Create
        public IActionResult Create()
        {
            ViewData["FitnessTypeId"] = new SelectList(_context.FitnessType, "FitnessProgramId", "Description");
            return View();
        }

        // POST: FitnessPrograms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FitnessTypeId")] FitnessProgram fitnessProgram)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fitnessProgram);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FitnessTypeId"] = new SelectList(_context.FitnessType, "FitnessProgramId", "Description", fitnessProgram.FitnessTypeId);
            return View(fitnessProgram);
        }

        // GET: FitnessPrograms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FitnessProgram == null)
            {
                return NotFound();
            }

            var fitnessProgram = await _context.FitnessProgram.FindAsync(id);
            if (fitnessProgram == null)
            {
                return NotFound();
            }
            ViewData["FitnessTypeId"] = new SelectList(_context.FitnessType, "FitnessProgramId", "Description", fitnessProgram.FitnessTypeId);
            return View(fitnessProgram);
        }

        // POST: FitnessPrograms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FitnessTypeId")] FitnessProgram fitnessProgram)
        {
            if (id != fitnessProgram.Id)
            {
                return NotFound();
            }

            if (id == fitnessProgram.Id)
            {
                try
                {
                    _context.Update(fitnessProgram);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FitnessProgramExists(fitnessProgram.Id))
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
            ViewData["FitnessTypeId"] = new SelectList(_context.FitnessType, "FitnessProgramId", "Description", fitnessProgram.FitnessTypeId);
            return View(fitnessProgram);
        }

        // GET: FitnessPrograms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FitnessProgram == null)
            {
                return NotFound();
            }

            var fitnessProgram = await _context.FitnessProgram
                .Include(f => f.FitnessType)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fitnessProgram == null)
            {
                return NotFound();
            }

            return View(fitnessProgram);
        }

        // POST: FitnessPrograms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FitnessProgram == null)
            {
                return Problem("Entity set 'AppDbContext.FitnessProgram'  is null.");
            }
            var fitnessProgram = await _context.FitnessProgram.FindAsync(id);
            if (fitnessProgram != null)
            {
                _context.FitnessProgram.Remove(fitnessProgram);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FitnessProgramExists(int id)
        {
          return _context.FitnessProgram.Any(e => e.Id == id);
        }
    }
}
