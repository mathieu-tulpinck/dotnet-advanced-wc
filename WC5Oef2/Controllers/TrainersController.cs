using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using WC5Oef2.Data;
using WC5Oef2.Models;
using WC5Oef2.ViewModels;

namespace WC5Oef2.Controllers
{
    [Authorize]
    public class TrainersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Trainer> _userManager;

        public TrainersController(ApplicationDbContext context, UserManager<Trainer> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var capturedPokemons = await _context.Pokemons.Where(p => p.TrainerId == currentUserId).ToListAsync();
            //var capturedPokemons = await _context.Trainers.Include(t => t.Pokemons).FirstOrDefaultAsync(t => t.Id == currentUserId);
            //var capturedPokemons = _context.Entry(currentUser).Collection(t => t.Pokemons).Load();

            if (capturedPokemons is null) {

                return RedirectToAction("GetCaptureRandomPokemon");
            }

            var viewModel = new TrainersIndexViewModel { CapturedPokemons = capturedPokemons };

            return View(viewModel);
        }

        public IActionResult GetCaptureRandomPokemon()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CaptureRandomPokemon()
        {
            var key = RandomNumberGenerator.GetInt32(1, 4);
            var random = await _context.Pokemons.FindAsync(key);
            var currentUser = await _userManager.GetUserAsync(User);
            random.Trainer = currentUser;
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
