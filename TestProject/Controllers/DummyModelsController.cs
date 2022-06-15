using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Data;
using TestProject.Models;
using TestProject.ViewModels;

namespace TestProject.Controllers
{
    public class DummyModelsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<DummyModelsController> _logger;

        public DummyModelsController(ILogger<DummyModelsController> logger, ApplicationDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        // GET: DummyModels
        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("Index route visited");

            var dummyModels = await _context.DummyModels.ToListAsync();

            var viewModel = new DummyModelsIndexViewModel { DummyModels = dummyModels };

            return View(viewModel);
        }

        // GET: DummyModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) {
                return NotFound();
            }

            var dummyModel = await _context.DummyModels.FirstOrDefaultAsync(m => m.Id == id);
            if (dummyModel == null) {
                return NotFound();
            }

            return View(dummyModel);
        }

        // GET: DummyModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DummyModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] DummyModel dummyModel)
        {
            if (ModelState.IsValid) {
                _context.Add(dummyModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dummyModel);
        }

        // GET: DummyModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) {
                return NotFound();
            }

            var dummyModel = await _context.DummyModels.FindAsync(id);
            if (dummyModel == null) {
                return NotFound();
            }
            return View(dummyModel);
        }

        // POST: DummyModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] DummyModel dummyModel)
        {
            if (id != dummyModel.Id) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(dummyModel);
                    await _context.SaveChangesAsync();
                } catch (DbUpdateConcurrencyException) {
                    if (!DummyModelExists(dummyModel.Id)) {
                        return NotFound();
                    } else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(dummyModel);
        }

        // GET: DummyModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) {
                return NotFound();
            }

            var dummyModel = await _context.DummyModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dummyModel == null) {
                return NotFound();
            }

            return View(dummyModel);
        }

        // POST: DummyModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dummyModel = await _context.DummyModels.FindAsync(id);
            _context.DummyModels.Remove(dummyModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DummyModelExists(int id)
        {
            return _context.DummyModels.Any(e => e.Id == id);
        }
    }
}
