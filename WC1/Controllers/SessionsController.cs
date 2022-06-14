using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WC1.Controllers
{
    public class SessionsController : Controller
    {
        private const string SessionKeyVisitorsCount = "_VisitorsCount";
        private const string SessionKeyUser = "_User";

        public IActionResult Index()
        {
            if (!(HttpContext.Session.GetInt32(SessionKeyVisitorsCount) is int teller)) {
                teller = 0;
            }

            HttpContext.Session.SetInt32(SessionKeyVisitorsCount, ++teller);

            ViewBag.Visitors = teller;

            return View();
        }

        public IActionResult Input()
        {
            if (TempData["Message"] != null) {
                ViewBag.ErrorMessage = TempData["Message"];
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Input(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName)) {
                ViewBag.ErrorMessage = "Please provide user name.";
            } else {
                HttpContext.Session.SetString(SessionKeyUser, userName);
                return RedirectToAction(nameof(ShowUser));
            }

            return View();
        }

        public IActionResult ShowUser()
        {
            var userName = HttpContext.Session.GetString(SessionKeyUser);

            if (userName == null) {
                TempData["Message"] = "User name not yet provided...";

                return RedirectToAction(nameof(Input));
            }

            ViewBag.User = userName;
            return View();
        }
    }
}
