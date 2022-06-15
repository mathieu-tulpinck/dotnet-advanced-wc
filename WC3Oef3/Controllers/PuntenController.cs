using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WC3Oef3.Data;
using WC3Oef3.Models;

namespace WC3Oef3.Controllers
{
    public class PuntenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PuntenController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Punten
        public async Task<IActionResult> Index()
        {
            var studentenMetPunten = _context.Studenten.Include(s => s.Punten).ThenInclude(p => p.Vak);
            return View(await studentenMetPunten.ToListAsync());
        }

        // GET: Punten/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) {
                return NotFound();
            }

            var punt = await _context.Punten
                .Include(p => p.Student)
                .Include(p => p.Vak)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (punt == null) {
                return NotFound();
            }

            return View(punt);
        }

        // GET: Punten/Create
        public IActionResult Create()
        {
            ViewData["StudentId"] = new SelectList(_context.Studenten.OrderBy(s => s.Naam), nameof(Student.Id), nameof(Student.Naam));
            ViewData["VakId"] = new SelectList(_context.Vakken.OrderBy(v => v.Naam), nameof(Vak.Id), nameof(Vak.Naam));
            return View();
        }

        // POST: Punten/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,VakId,StudentId,Score")] Punt punt)
        {
            if (ModelState.IsValid) {
                _context.Add(punt);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(_context.Studenten.OrderBy(s => s.Naam), nameof(Student.Id), nameof(Student.Naam), punt.StudentId);
            ViewData["VakId"] = new SelectList(_context.Vakken.OrderBy(v => v.Naam), nameof(Vak.Id), nameof(Vak.Naam), punt.VakId);

            return View(punt);
        }

        // GET: Punten/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) {
                return NotFound();
            }

            var punt = await _context.Punten.FindAsync(id);
            if (punt == null) {
                return NotFound();
            }
            ViewData["StudentId"] = new SelectList(_context.Studenten.OrderBy(s => s.Naam), nameof(Student.Id), nameof(Student.Naam), punt.StudentId);
            ViewData["VakId"] = new SelectList(_context.Vakken.OrderBy(v => v.Naam), nameof(Vak.Id), nameof(Vak.Naam), punt.VakId);
            return View(punt);
        }

        // POST: Punten/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,VakId,StudentId,Score")] Punt punt)
        {
            if (id != punt.Id) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(punt);
                    await _context.SaveChangesAsync();
                } catch (DbUpdateConcurrencyException) {
                    if (!PuntExists(punt.Id)) {
                        return NotFound();
                    } else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(_context.Studenten.OrderBy(s => s.Naam), nameof(Student.Id), nameof(Student.Naam), punt.StudentId);
            ViewData["VakId"] = new SelectList(_context.Vakken.OrderBy(v => v.Naam), nameof(Vak.Id), nameof(Vak.Naam), punt.VakId);
            return View(punt);
        }

        // GET: Punten/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) {
                return NotFound();
            }

            var punt = await _context.Punten
                .Include(p => p.Student)
                .Include(p => p.Vak)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (punt == null) {
                return NotFound();
            }

            return View(punt);
        }

        // POST: Punten/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var punt = await _context.Punten.FindAsync(id);
            _context.Punten.Remove(punt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PuntExists(int id)
        {
            return _context.Punten.Any(e => e.Id == id);
        }
    }
}
