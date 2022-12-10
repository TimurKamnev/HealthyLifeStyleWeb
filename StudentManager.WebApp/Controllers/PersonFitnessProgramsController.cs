using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fitness.Infrastracture;
using StudentManager.Backend.Entities;
using Microsoft.VisualStudio.Web.CodeGeneration.Design;
using System.Security.Claims;

namespace StudentManager.WebApp.Controllers
{
    public class PersonFitnessProgramsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PersonFitnessProgramsController(AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET: PersonFitnessPrograms
        public async Task<IActionResult> Index()
        {
            string? userId = _httpContextAccessor
                .HttpContext?
                .User?
                .FindFirstValue(ClaimTypes.NameIdentifier);

            var appDbContext = _context
                .PersonFitnessProgram
                .Include(p => p.FitnessType)
                .Include(p => p.Person)
                .Where(p => p.Person.Id == userId).ToList();

            return View(appDbContext);
        }

        // GET: PersonFitnessPrograms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PersonFitnessProgram == null)
            {
                return NotFound();
            }

            var personFitnessProgram = await _context.PersonFitnessProgram
                .Include(p => p.FitnessType)
                .Include(p => p.Person)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personFitnessProgram == null)
            {
                return NotFound();
            }

            return View(personFitnessProgram);
        }

        // GET: PersonFitnessPrograms/Create
        public IActionResult Create()
        {
            ViewData["FitnessTypeId"] = new SelectList(_context.FitnessType, "FitnessProgramId", "Name");
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FirstName");
            return View();
        }

        // POST: PersonFitnessPrograms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonId,FitnessTypeId,IsCurrent")] PersonFitnessProgram personFitnessProgram)
        {
            if (!(personFitnessProgram.PersonId == null || personFitnessProgram.FitnessTypeId == 0))
            {
                _context.Add(personFitnessProgram);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FitnessTypeId"] = new SelectList(_context.FitnessType, "FitnessProgramId", "Description", personFitnessProgram.FitnessTypeId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FirstName", personFitnessProgram.PersonId);
            return View(personFitnessProgram);
        }

        // GET: PersonFitnessPrograms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PersonFitnessProgram == null)
            {
                return NotFound();
            }

            var personFitnessProgram = await _context.PersonFitnessProgram.FindAsync(id);
            if (personFitnessProgram == null)
            {
                return NotFound();
            }
            ViewData["FitnessTypeId"] = new SelectList(_context.FitnessType, "FitnessProgramId", "Description", personFitnessProgram.FitnessTypeId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FirstName", personFitnessProgram.PersonId);
            return View(personFitnessProgram);
        }

        // POST: PersonFitnessPrograms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PersonId,FitnessTypeId,IsCurrent")] PersonFitnessProgram personFitnessProgram)
        {
            if (id != personFitnessProgram.Id)
            {
                return NotFound();
            }

            if (id == personFitnessProgram.Id)
            {
                try
                {
                    _context.Update(personFitnessProgram);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonFitnessProgramExists(personFitnessProgram.Id))
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
            ViewData["FitnessTypeId"] = new SelectList(_context.FitnessType, "FitnessProgramId", "Description", personFitnessProgram.FitnessTypeId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id", personFitnessProgram.PersonId);
            return View(personFitnessProgram);
        }

        // GET: PersonFitnessPrograms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PersonFitnessProgram == null)
            {
                return NotFound();
            }

            var personFitnessProgram = await _context.PersonFitnessProgram
                .Include(p => p.FitnessType)
                .Include(p => p.Person)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personFitnessProgram == null)
            {
                return NotFound();
            }

            return View(personFitnessProgram);
        }

        // POST: PersonFitnessPrograms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PersonFitnessProgram == null)
            {
                return Problem("Entity set 'AppDbContext.PersonFitnessProgram'  is null.");
            }
            var personFitnessProgram = await _context.PersonFitnessProgram.FindAsync(id);
            if (personFitnessProgram != null)
            {
                _context.PersonFitnessProgram.Remove(personFitnessProgram);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonFitnessProgramExists(int id)
        {
          return _context.PersonFitnessProgram.Any(e => e.Id == id);
        }
    }
}
