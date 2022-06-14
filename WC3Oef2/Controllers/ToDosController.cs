using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WC3Oef2.Data;
using WC3Oef2.Models;

namespace WC3Oef2.Controllers
{
    public class ToDosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ToDosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ToDos
        public async Task<IActionResult> Index()
        {
            return View(await _context.ToDos.ToListAsync());
        }

        // GET: ToDos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) {
                return NotFound();
            }

            var toDo = await _context.ToDos.FirstOrDefaultAsync(m => m.Id == id);
            if (toDo == null) {
                return NotFound();
            }

            return View(toDo);
        }

        // GET: ToDos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ToDos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Date,Description")] ToDo toDo)
        {
            if (ModelState.IsValid) {
                _context.Add(toDo);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(toDo);
        }

        // GET: ToDos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) {

                return NotFound();
            }

            var toDo = await _context.ToDos.FindAsync(id);
            if (toDo == null) {

                return NotFound();
            }

            return View(toDo);
        }

        // POST: ToDos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Date,Description")] ToDo toDo)
        {
            if (id != toDo.Id) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(toDo);
                    await _context.SaveChangesAsync();
                } catch (DbUpdateConcurrencyException) {
                    if (!ToDoExists(toDo.Id)) {
                        return NotFound();
                    } else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(toDo);
        }

        // GET: ToDos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) {
                return NotFound();
            }

            var toDo = await _context.ToDos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (toDo == null) {
                return NotFound();
            }

            return View(toDo);
        }

        // POST: ToDos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var toDo = await _context.ToDos.FindAsync(id);
            _context.ToDos.Remove(toDo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ToDoExists(int id)
        {
            return _context.ToDos.Any(e => e.Id == id);
        }
    }
}
