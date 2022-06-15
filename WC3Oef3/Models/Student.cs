using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WC3Oef3.Models
{
    public class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Naam { get; set; }

        // navigation property
        public ICollection<Punt> Punten { get; set; }
    }
}
