using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WC7.Models
{
    public class ShoppingCartItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("ScreeningId")]
        public Screening Screening { get; set; }
        public int ScreeningId { get; set; }

        [Range(1, 15)]
        public byte Amount { get; set; }

        public string ShoppingCartId { get; set; }
    }
}
