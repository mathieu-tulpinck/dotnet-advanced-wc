using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace WC5Oef2.Models
{
    public class Trainer : IdentityUser
    {
        // navigation property
        public IEnumerable<Pokemon> Pokemons { get; set; }
    }
}
