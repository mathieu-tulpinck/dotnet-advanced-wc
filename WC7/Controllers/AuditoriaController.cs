using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WC7.Data;
using WC7.Models;

namespace WC7.Controllers
{
    [Authorize(Roles = "admin,staff")]
    public class AuditoriaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AuditoriaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Auditoria
        public async Task<IActionResult> Index()
        {
            return View(await _context.Auditoria.ToListAsync());
        }

        // GET: Auditoria/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) {
                return NotFound();
            }

            var auditorium = await _context.Auditoria.FirstOrDefaultAsync(m => m.Id == id);
            if (auditorium == null) {
                return NotFound();
            }

            return View(auditorium);
        }

        // GET: Auditoria/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Auditoria/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Capacity")] Auditorium auditorium)
        {
            if (ModelState.IsValid) {
                _context.Add(auditorium);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(auditorium);
        }

        // GET: Auditoria/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) {
                return NotFound();
            }

            var auditorium = await _context.Auditoria.FindAsync(id);
            if (auditorium == null) {

                return NotFound();
            }
            return View(auditorium);
        }

        // POST: Auditoria/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Capacity")] Auditorium auditorium)
        {
            if (id != auditorium.Id) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(auditorium);
                    await _context.SaveChangesAsync();
                } catch (DbUpdateConcurrencyException) {
                    if (!AuditoriumExists(auditorium.Id)) {

                        return NotFound();
                    } else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(auditorium);
        }

        // GET: Auditoria/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) {
                return NotFound();
            }

            var auditorium = await _context.Auditoria.FirstOrDefaultAsync(m => m.Id == id);
            if (auditorium == null) {
                return NotFound();
            }

            return View(auditorium);
        }

        // POST: Auditoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var auditorium = await _context.Auditoria.FindAsync(id);
            _context.Auditoria.Remove(auditorium);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool AuditoriumExists(int id)
        {
            return _context.Auditoria.Any(e => e.Id == id);
        }
    }
}
