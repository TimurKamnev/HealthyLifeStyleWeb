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
    public class AchievementsController : Controller
    {
        private readonly AppDbContext _context;

        public AchievementsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Achievements
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Achievement.Include(a => a.Person);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Achievements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Achievement == null)
            {
                return NotFound();
            }

            var achievement = await _context.Achievement
                .Include(a => a.Person)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (achievement == null)
            {
                return NotFound();
            }

            return View(achievement);
        }

        // GET: Achievements/Create
        public IActionResult Create()
        {
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FirstName");
            return View();
        }

        // POST: Achievements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PersonId,Period")] Achievement achievement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(achievement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FirstName", achievement.PersonId);
            return View(achievement);
        }

        // GET: Achievements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Achievement == null)
            {
                return NotFound();
            }

            var achievement = await _context.Achievement.FindAsync(id);
            if (achievement == null)
            {
                return NotFound();
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FirstName", achievement.PersonId);
            return View(achievement);
        }

        // POST: Achievements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PersonId,Period")] Achievement achievement)
        {
            if (id != achievement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(achievement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AchievementExists(achievement.Id))
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
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FirstName", achievement.PersonId);
            return View(achievement);
        }

        // GET: Achievements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Achievement == null)
            {
                return NotFound();
            }

            var achievement = await _context.Achievement
                .Include(a => a.Person)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (achievement == null)
            {
                return NotFound();
            }

            return View(achievement);
        }

        // POST: Achievements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Achievement == null)
            {
                return Problem("Entity set 'AppDbContext.Achievement'  is null.");
            }
            var achievement = await _context.Achievement.FindAsync(id);
            if (achievement != null)
            {
                _context.Achievement.Remove(achievement);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AchievementExists(int id)
        {
          return _context.Achievement.Any(e => e.Id == id);
        }
    }
}
