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
            //Console.Out.WriteLine("Current ProcessID: " + Process.GetCurrentProcess().Id); //This prints the process id
            //Console.Out.WriteLine("Waiting for debugger to attach...");
            //while (!Debugger.IsAttached) {
            //    Thread.Sleep(100);
            //}
            //Console.Out.WriteLine("Debugger attached.");
        }

        public DbSet<Pokemon> Pokemons { get; set; }
        public DbSet<Trainer> Trainers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Trainer>().ToTable("Trainers", "dbo");
            builder.Entity<Pokemon>().ToTable("Pokemons", "dbo");

            var pokemon1 = Pokemon.CreatePokemon(1, "Pikachu").Result;
            var pokemon2 = Pokemon.CreatePokemon(2, "Eevee").Result;
            var pokemon3 = Pokemon.CreatePokemon(3, "Snorlax").Result;

            builder.Entity<Pokemon>().HasData(
                pokemon1,
                pokemon2,
                pokemon3
            );
        }
    }
}
