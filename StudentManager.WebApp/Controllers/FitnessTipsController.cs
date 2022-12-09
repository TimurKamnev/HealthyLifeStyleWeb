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
    public class FitnessTipsController : Controller
    {
        private readonly AppDbContext _context;

        public FitnessTipsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: FitnessTips
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.FitnessTip.Include(f => f.FitnessProgram);
            return View(await appDbContext.ToListAsync());
        }

        // GET: FitnessTips/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FitnessTip == null)
            {
                return NotFound();
            }

            var fitnessTip = await _context.FitnessTip
                .Include(f => f.FitnessProgram)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fitnessTip == null)
            {
                return NotFound();
            }

            return View(fitnessTip);
        }

        // GET: FitnessTips/Create
        public IActionResult Create()
        {
            ViewData["FitnessProgramId"] = new SelectList(_context.FitnessProgram, "Id", "Id");
            return View();
        }

        // POST: FitnessTips/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,FitnessProgramId")] FitnessTip fitnessTip)
        {
            if (fitnessTip.Id == 0)
            {
                _context.Add(fitnessTip);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FitnessProgramId"] = new SelectList(_context.FitnessProgram, "Id", "Id", fitnessTip.FitnessProgramId);
            return View(fitnessTip);
        }

        // GET: FitnessTips/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FitnessTip == null)
            {
                return NotFound();
            }

            var fitnessTip = await _context.FitnessTip.FindAsync(id);
            if (fitnessTip == null)
            {
                return NotFound();
            }
            ViewData["FitnessProgramId"] = new SelectList(_context.FitnessProgram, "Id", "Id", fitnessTip.FitnessProgramId);
            return View(fitnessTip);
        }

        // POST: FitnessTips/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,FitnessProgramId")] FitnessTip fitnessTip)
        {
            if (id != fitnessTip.Id)
            {
                return NotFound();
            }

            if (id == fitnessTip.Id)
            {
                try
                {
                    _context.Update(fitnessTip);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FitnessTipExists(fitnessTip.Id))
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
            ViewData["FitnessProgramId"] = new SelectList(_context.FitnessProgram, "Id", "Id", fitnessTip.FitnessProgramId);
            return View(fitnessTip);
        }

        // GET: FitnessTips/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FitnessTip == null)
            {
                return NotFound();
            }

            var fitnessTip = await _context.FitnessTip
                .Include(f => f.FitnessProgram)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fitnessTip == null)
            {
                return NotFound();
            }

            return View(fitnessTip);
        }

        // POST: FitnessTips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FitnessTip == null)
            {
                return Problem("Entity set 'AppDbContext.FitnessTip'  is null.");
            }
            var fitnessTip = await _context.FitnessTip.FindAsync(id);
            if (fitnessTip != null)
            {
                _context.FitnessTip.Remove(fitnessTip);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FitnessTipExists(int id)
        {
          return _context.FitnessTip.Any(e => e.Id == id);
        }
    }
}
