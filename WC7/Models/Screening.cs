using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using WC7.Data;

namespace WC7.Models
{
    public class Screening
    {
        private readonly ApplicationDbContext _context;

        public Screening()
        {

        }

        public Screening(ApplicationDbContext context)
        {
            _context = context;
        }

        public Screening(int id, int auditoriumId, int movieId, DateTime start, DateTime end, int availableSeats)
        {
            Id = id;
            AuditoriumId = auditoriumId;
            MovieId = movieId;
            Start = start;
            End = end;
            AvailableSeats = availableSeats;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("AuditoriumId")]
        public Auditorium Auditorium { get; set; }
        public int AuditoriumId { get; set; }

        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }
        public int MovieId { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        [Display(Name = "Available seats")]
        public int AvailableSeats { get; set; }

        public void UpdateAvailability(int amount)
        {
            int resultingAvailability = AvailableSeats + amount;
            var auditorium = _context.Auditoria.SingleOrDefault(a => a.Id == AuditoriumId);
            if (resultingAvailability > 0 && resultingAvailability < auditorium.Capacity) {
                this.AvailableSeats = resultingAvailability;
                _context.Screenings.Update(this);
                _context.SaveChanges();
            }
        }
    }
}
