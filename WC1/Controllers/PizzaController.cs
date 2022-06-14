using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WC1.Models;

namespace WC1.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Order()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Show([Bind("Client,Type,ExtraCheese,PaymentMethod")] Pizza pizza)
        {
            List<string> errors = new List<string>();
            if (string.IsNullOrWhiteSpace(pizza.Client)) {
                errors.Add("Please provide the name of the client.");
            }

            if (string.IsNullOrWhiteSpace(pizza.Type)) {
                errors.Add("Please provide the pizza type.");
            }

            if (string.IsNullOrWhiteSpace(pizza.PaymentMethod)) {
                errors.Add("Please provide the payment method.");
            }

            ViewBag.Errors = errors;

            return View(pizza);
        }
    }
}
