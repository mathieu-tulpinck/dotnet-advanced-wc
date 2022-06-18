using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace WC7.Components
{
    public class AdminLinks : ViewComponent
    {
        private readonly UserManager<IdentityUser> _userManager;
        private IdentityUser _currentUser;

        public AdminLinks(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (User.Identity.IsAuthenticated) {
                _currentUser = _userManager.GetUserAsync(UserClaimsPrincipal).Result;
                var roles = await _userManager.GetRolesAsync(_currentUser);
                if (roles.ToList().First() == "admin") {
                    ViewBag.Role = "admin";
                    return View();
                } else if (roles.ToList().First() == "staff") {
                    ViewBag.Role = "staff";
                    return View();
                }
            }

            return View();
        }
    }
}
