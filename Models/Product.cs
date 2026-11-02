using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace BE5_CustomerSite.Models
{
    [MetadataType(typeof(Metadata.ProductMetadata))]
    public partial class Product
    {
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductImage { get; set; }

        [NotMapped]
        public HttpPostedFileBase UploadImg { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        [NotMapped]
        public int SoldQuantity { get; set; }
    }
}
