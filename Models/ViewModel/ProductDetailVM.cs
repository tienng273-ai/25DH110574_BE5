using System.Collections.Generic;
using BE5_CustomerSite.Models;

namespace BE5_CustomerSite.Models.ViewModel
{
    public class ProductDetailVM
    {
        public Product Product { get; set; }
        public List<Product> RelatedProducts { get; set; }
        public List<Product> TopProducts { get; set; }
        public int Quantity { get; set; }
        public int Page { get; set; }
    }
}
