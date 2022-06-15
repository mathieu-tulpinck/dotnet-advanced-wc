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

            builder.Entity<Trainer>().ToTable("Trainers", "dbo");
            builder.Entity<Pokemon>().ToTable("Pokemons", "dbo");

            builder.Entity<Pokemon>().HasData(
                    new Pokemon(1, "Pikachu"),
                    new Pokemon(2, "Eevee"),
                    new Pokemon(3, "Snorlax")
            );
        }

        public DbSet<Pokemon> Pokemons { get; set; }
    }
}
