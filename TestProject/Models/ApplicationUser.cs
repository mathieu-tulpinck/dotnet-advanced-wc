using Microsoft.AspNetCore.Identity;

namespace TestProject.Models
{
    public class ApplicationUser : IdentityUser
    {
        public byte Age { get; set; }
    }
}
