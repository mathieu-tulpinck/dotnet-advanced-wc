using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using WC7.Models;

namespace WC7.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Auditorium> Auditoria { get; set; }
        public DbSet<Screening> Screenings { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var movies = new List<Movie> {
                new Movie {
                    Id = 1,
                    Title = "test title 1",
                    Ranking = 80,
                    DirectorName = "test director 1"
                },
                new Movie {
                    Id = 2,
                    Title = "test title 2",
                    Ranking = 100,
                    DirectorName = "test director 2"
                },
            };

            var auditoria = new List<Auditorium> {
                new Auditorium {
                    Id = 1,
                    Capacity = 10
                },
                new Auditorium {
                    Id = 2,
                    Capacity = 50
                }
            };

            var t = DateTime.Now;
            var tPlus2 = t.AddHours(2);
            var tPlus1Day = t.AddDays(1);
            var tPlus1DayPlus2 = tPlus1Day.AddHours(2);
            var tPlus1Week = t.AddDays(7);
            var tPlus1WeekPlus2 = tPlus1Week.AddHours(2);

            var screenings = new List<Screening> {
                // Today.
                new Screening {
                    Id = 1,
                    AuditoriumId = auditoria[0].Id,
                    MovieId = auditoria[0].Id,
                    Start = t,
                    End = tPlus2,
                    AvailableSeats = auditoria[0].Capacity
                },
                // This week.
                new Screening {
                    Id = 2,
                    AuditoriumId = auditoria[1].Id,
                    MovieId = auditoria[1].Id,
                    Start = tPlus1Day,
                    End = tPlus1DayPlus2,
                    AvailableSeats = auditoria[1].Capacity
                },
                // Next week.
                new Screening {
                    Id = 3,
                    AuditoriumId = auditoria[0].Id,
                    MovieId = auditoria[1].Id,
                    Start = tPlus1Week,
                    End = tPlus1WeekPlus2,
                    AvailableSeats = auditoria[0].Capacity
                },
            };

            builder.Entity<Movie>().HasData(movies);
            builder.Entity<Auditorium>().HasData(auditoria);
            builder.Entity<Screening>().HasData(screenings);
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole {
                    Name = "admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole {
                    Name = "staff",
                    NormalizedName = "STAFF"
                },
                new IdentityRole {
                    Name = "user",
                    NormalizedName = "USER"
                }
            );
        }
    }
}
