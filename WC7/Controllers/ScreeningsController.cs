using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WC7.Data;
using WC7.Extensions;
using WC7.Models;

namespace WC7.Controllers
{
    public class ScreeningsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ScreeningsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Screenings
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Screenings
                .Include(s => s.Auditorium)
                .Include(s => s.Movie);

            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> GetTodayScreenings()
        {
            var todayScreenings = await _context.Screenings
                .Where(s => s.Start.DayOfYear == DateTime.Now.DayOfYear)
                .Include(s => s.Auditorium)
                .Include(s => s.Movie)
                .ToListAsync();

            return View(nameof(Index), todayScreenings);
        }

        public async Task<IActionResult> GetWeeklyScreenings(int? weekIndex)
        {
            DateTime t;
            if (weekIndex != null) {
                t = DateTime.Now.AddDays((double)weekIndex * 7);
            } else {
                t = DateTime.Now;
            }
            var startOfWeek = t.StartOfWeek(DayOfWeek.Monday);
            var endOfWeek = startOfWeek.AddDays(6).AddHours(23).AddMinutes(59).AddSeconds(59);


            var weeklyScreenings = await _context.Screenings
                .Where(s => s.Start >= startOfWeek)
                .Where(s => s.End <= endOfWeek)
                .Include(s => s.Auditorium)
                .Include(s => s.Movie)
                .ToListAsync();

            return View(nameof(Index), weeklyScreenings);
        }

        // GET: Screenings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) {
                return NotFound();
            }

            var screening = await _context.Screenings
                .Include(s => s.Auditorium)
                .Include(s => s.Movie)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (screening == null) {
                return NotFound();
            }

            return View(screening);
        }

        // GET: Screenings/Create
        public IActionResult Create()
        {
            ViewData["AuditoriumId"] = new SelectList(_context.Auditoria, "Id", "Id");
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Id");

            return View();
        }

        // POST: Screenings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AuditoriumId,MovieId,Start,End")] Screening screening)
        {
            if (ModelState.IsValid) {
                _context.Add(screening);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewData["AuditoriumId"] = new SelectList(_context.Auditoria, "Id", "Id", screening.AuditoriumId);
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Id", screening.MovieId);

            return View(screening);
        }

        // GET: Screenings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) {
                return NotFound();
            }

            var screening = await _context.Screenings.FindAsync(id);

            if (screening == null) {
                return NotFound();
            }
            ViewData["AuditoriumId"] = new SelectList(_context.Auditoria, "Id", "Id", screening.AuditoriumId);
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Id", screening.MovieId);

            return View(screening);
        }

        // POST: Screenings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AuditoriumId,MovieId,Start,End")] Screening screening)
        {
            if (id != screening.Id) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(screening);
                    await _context.SaveChangesAsync();
                } catch (DbUpdateConcurrencyException) {
                    if (!ScreeningExists(screening.Id)) {
                        return NotFound();
                    } else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["AuditoriumId"] = new SelectList(_context.Auditoria, "Id", "Id", screening.AuditoriumId);
            ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Id", screening.MovieId);

            return View(screening);
        }

        // GET: Screenings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) {
                return NotFound();
            }

            var screening = await _context.Screenings
                .Include(s => s.Auditorium)
                .Include(s => s.Movie)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (screening == null) {
                return NotFound();
            }

            return View(screening);
        }

        // POST: Screenings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var screening = await _context.Screenings.FindAsync(id);
            _context.Screenings.Remove(screening);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ScreeningExists(int id)
        {
            return _context.Screenings.Any(e => e.Id == id);
        }
    }
}
