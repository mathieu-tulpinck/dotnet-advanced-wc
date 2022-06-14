using System.ComponentModel.DataAnnotations.Schema;

namespace WC3Oef3.Models
{
    public class Vak
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Naam { get; set; }
    }
}
