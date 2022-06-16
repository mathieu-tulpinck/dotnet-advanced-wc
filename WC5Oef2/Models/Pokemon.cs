using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Http;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace WC5Oef2.Models
{
    public class Pokemon
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public Pokemon(int id, string name, IHttpClientFactory httpClientFactory)
        {
            Id = id;
            Name = name;
            Lives = (byte)RandomNumberGenerator.GetInt32(1, 101);
            Speed = (byte)RandomNumberGenerator.GetInt32(1, 101);
            Thumbnail = await GetThumbnail();
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

        public async Task<byte[]> GetThumbnail()
        {

        }
    }
}
