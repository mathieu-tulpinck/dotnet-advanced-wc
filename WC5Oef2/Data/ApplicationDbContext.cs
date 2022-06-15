using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WC5Oef2.Models;

namespace WC5Oef2.Data
{
    public class ApplicationDbContext : IdentityDbContext<Trainer>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Pokemon>().ToTable("Pokemons", "dbo");

            builder.Entity<Pokemon>().HasData(
                    new Pokemon("Pikachu"),
                    new Pokemon("Eevee"),
                    new Pokemon("Snorlax")
            );
        }
    }
}
