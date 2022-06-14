using System.ComponentModel.DataAnnotations;
using WC3Oef1.Enums;

namespace WC3Oef1.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Category")]
        public Category Category { get; set; }
        [DataType(DataType.Currency)]
        [Display(Name = "Price")]
        public decimal Price { get; set; }
        [Display(Name = "Amount")]
        public uint Amount { get; set; }

        public override string ToString()
        {
            return $"Id={Id}, Name={Name}, Description={Description}, Category={Category}, Price={Price}, Amount={Amount}";
        }
    }
}