using Microsoft.AspNetCore.Mvc;

namespace WC1.Controllers
{
    public class RegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register(string email, string mailClient, string password)
        {
            if (!string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(password)) {
                ViewBag.Message = "Succesfull registration.";
            } else {
                ViewBag.Email = email;
                ViewBag.Client = mailClient;
            }

            return View("Index");
        }
    }
}
