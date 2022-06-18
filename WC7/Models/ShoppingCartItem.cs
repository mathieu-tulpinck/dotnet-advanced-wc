using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WC7.Models
{
    public class ShoppingCartItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [ForeignKey("ScreeningId")]
        public Screening Screening { get; set; }
        public int ScreeningId { get; set; }

        [Required]
        [Range(1, 15, ErrorMessage = "Please contact our staff to purchase > 15 tickets")]
        public int Amount { get; set; }

        public string ShoppingCartId { get; set; }
    }
}
