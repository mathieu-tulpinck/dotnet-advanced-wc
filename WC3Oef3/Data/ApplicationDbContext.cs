using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WC3Oef3.Models;

namespace WC3Oef3.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Studenten { get; set; }
        public DbSet<Vak> Vakken { get; set; }
        public DbSet<Punt> Punten { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // voegt UNIQUE constraint toe aan Vak.Naam (zie: https://docs.microsoft.com/en-us/ef/core/modeling/indexes?tabs=fluent-api#index-uniqueness)
            // vanaf EF Core 5 gaat dit ook met Data Annotations
            modelBuilder.Entity<Vak>()
                .HasIndex(v => v.Naam)
                .IsUnique();

            var vakken = new List<Vak> {
                new Vak { Id = 1, Naam = ".NET Essentials" },
                new Vak { Id = 2, Naam = ".NET Advanced" },
                new Vak { Id = 3, Naam = "Programming Essentials" },
                new Vak { Id = 4, Naam = "Programming Advanced" },
                new Vak { Id = 5, Naam = "Data Essentials" },
                new Vak { Id = 6, Naam = "Data Advanced" }
            };

            var studenten = new List<Student> {
                new Student { Id = 1, Naam = "Paul" },
                new Student { Id = 2, Naam = "Marvin" },
                new Student { Id = 3, Naam = "Michael" },
                new Student { Id = 4, Naam = "Amber" },
                new Student { Id = 5, Naam = "Anna" },
                new Student { Id = 6, Naam = "Belle" },
                new Student { Id = 7, Naam = "Carrie" },
                new Student { Id = 8, Naam = "Wim"}
            };

            var punten = new List<Punt> {
                new Punt { Id = 1, VakId = vakken[0].Id, StudentId = studenten[7].Id, Score = 20 }
            };

            modelBuilder.Entity<Vak>().HasData(
                vakken[0],
                vakken[1],
                vakken[2],
                vakken[3],
                vakken[4],
                vakken[5]
            );

            modelBuilder.Entity<Student>().HasData(
                studenten[0],
                studenten[1],
                studenten[2],
                studenten[3],
                studenten[4],
                studenten[5],
                studenten[6],
                studenten[7]
            );

            modelBuilder.Entity<Punt>().HasData(
                punten[0]);

        }
    }
}
