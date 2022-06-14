using System.Collections.Generic;
using WC3Oef1.Models;

namespace WC3Oef1.ViewModels
{
    public class OrderedProductsViewModel
    {
        public IEnumerable<Product> OrderedProducts { get; set; }
    }
}
