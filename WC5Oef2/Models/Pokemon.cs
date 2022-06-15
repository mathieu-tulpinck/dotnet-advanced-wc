using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace WC5Oef2.Models
{
    public class Pokemon
    {

        public Pokemon(string name)
        {
            Name = name;
            Lives = RandomNumberGenerator.GetInt32(0, 100);
            Speed = RandomNumberGenerator.GetInt32(0, 100);
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(256)]
        public string Name { get; set; }

        [Range(0, 100)]
        public int Lives { get; set; }

        [Range(0, 100)]
        public int Speed { get; set; }

        // navigation property
        public Trainer Trainer { get; set; }
    }
}
