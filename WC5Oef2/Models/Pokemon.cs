using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace WC5Oef2.Models
{
    public class Pokemon
    {

        public Pokemon(int id, string name)
        {
            Id = id;
            Name = name;
            Lives = (byte)RandomNumberGenerator.GetInt32(1, 100);
            Speed = (byte)RandomNumberGenerator.GetInt32(1, 100);
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(256)]
        public string Name { get; set; }

        [Range(0, 100)]
        public byte Lives { get; set; }

        [Range(0, 100)]
        public byte Speed { get; set; }

        public byte[] Thumbnail { get; set; }

        // navigation property
        public virtual Trainer Trainer { get; set; }
    }
}
