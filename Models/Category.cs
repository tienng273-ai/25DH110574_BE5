using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace BE5_CustomerSite.Models
{
    [MetadataType(typeof(Metadata.CategoryMetadata))]
    public partial class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
