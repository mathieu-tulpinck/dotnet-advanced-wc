using System.ComponentModel.DataAnnotations.Schema;

namespace WC7.Models
{
    public class Auditorium
    {
        public Auditorium() { }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int Capacity { get; set; }

    }
}
