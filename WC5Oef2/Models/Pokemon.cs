using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Http;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace WC5Oef2.Models
{
    public class Pokemon
    {
        private Pokemon(int id, string name, byte[] thumbnail)
        {
            Id = id;
            Name = name;
            Lives = (byte)RandomNumberGenerator.GetInt32(1, 101);
            Speed = (byte)RandomNumberGenerator.GetInt32(1, 101);
            Thumbnail = thumbnail;
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
        [ForeignKey("TrainerId")]
        public Trainer Trainer { get; set; }
        public string TrainerId { get; set; }


        public static async Task<Pokemon> CreatePokemon(int id, string name)
        {
            using (var client = new HttpClient()) {
                var bytes = await client.GetByteArrayAsync("https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/1.png");

                return new Pokemon(id, name, bytes);
            }
        }

    }
}
