using System.Collections.Generic;
using BE5_CustomerSite.Models;
using PagedList;

namespace BE5_CustomerSite.Models.ViewModel
{
    public class HomeProductVM
    {
        public List<Product> FeaturedProducts { get; set; }
        public IPagedList<Product> NewProducts { get; set; }
        public string SearchTerm { get; set; }
    }
}
