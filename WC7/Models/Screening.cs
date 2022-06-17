using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WC7.Models
{
    public class Screening
    {
        public Screening() { }

        public Screening(int id, int auditoriumId, int movieId, DateTime start, DateTime end)
        {
            Id = id;
            AuditoriumId = auditoriumId;
            MovieId = movieId;
            Start = start;
            End = end;
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
    }
}
