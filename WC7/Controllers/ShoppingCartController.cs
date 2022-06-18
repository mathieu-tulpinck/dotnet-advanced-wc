using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WC7.Data;
using WC7.Models;
using WC7.ViewModels;

namespace WC7.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(ApplicationDbContext context, ShoppingCart shoppingCart)
        {
            _context = context;
            _shoppingCart = shoppingCart;
        }

        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel {
                ShoppingCart = _shoppingCart,
            };

            return View(shoppingCartViewModel);
        }

        public ViewResult GetAddToShoppingCart(int screeningId)
        {
            ViewBag.ScreeningId = screeningId;

            return View();
        }

        // Availability is calculated immediately, not on checkout.
        public RedirectToActionResult AddToShoppingCart([Bind("ScreeningId, Amount")] ShoppingCartItem shoppingCartItem)
        {
            var selectedScreening = _context.Screenings.FirstOrDefault(s => s.Id == shoppingCartItem.ScreeningId);

            if (selectedScreening != null) {
                _shoppingCart.AddToCart(selectedScreening, shoppingCartItem.Amount);
            }

            return RedirectToAction("Index"); // Redirect using the action name.
        }

        public RedirectToActionResult RemoveFromShoppingCart(int id)
        {
            var selectedScreening = _context.Screenings.FirstOrDefault(s => s.Id == id);

            if (selectedScreening != null) {
                _shoppingCart.RemoveFromCart(selectedScreening);

            }
            return RedirectToAction("Index");
        }
    }
}
