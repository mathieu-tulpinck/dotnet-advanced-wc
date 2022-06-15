using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WC5Oef1.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string Name { get; set; }

        //[DataType(DataType.Password)]
        //[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        //[Display(Name = "Confirm password")]
        //public string PasswordHashControl { get; set; }

        //[Required]
        //[StringLength(254)]
        //[DataType(DataType.EmailAddress)]
        //[ProtectedPersonalData]
        //public override string Email { get; set; }

        [Required]
        [Range(0, 150)]
        public int Age { get; set; }

        [Required]
        [StringLength(256)]
        public string FavoriteGame { get; set; }
    }
}
