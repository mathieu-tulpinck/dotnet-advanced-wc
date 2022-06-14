using System.Collections.Generic;
using WC3Oef1.Enums;
using WC3Oef1.Models;

namespace WC3Oef1.ViewModels
{
    public class HomeIndexViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public Category Category { get; set; }
    }
}
