using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WC3Oef1.Data;
using WC3Oef1.Enums;
using WC3Oef1.Models;
using WC3Oef1.ViewModels;

namespace WC3Oef1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<ViewResult> Index(Category category)
        {
            //if (category == null) {
            //    return View();
            //}

            var filteredProducts = await _context.Products.Where(p => p.Category == category).OrderBy(p => p.Name).ToListAsync();

            var viewModel = new HomeIndexViewModel {
                Products = filteredProducts,
                Category = category

            };

            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
