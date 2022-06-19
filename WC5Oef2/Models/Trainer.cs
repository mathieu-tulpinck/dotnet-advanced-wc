using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace WC5Oef2.Models
{
    public class Trainer : IdentityUser
    {
        // Navigation property.
        public ICollection<Pokemon> Pokemons { get; set; }
    }
}
