using System.ComponentModel.DataAnnotations;
namespace BE5_CustomerSite.Models
{
    [MetadataType(typeof(Metadata.OrderDetailMetadata))]
    public partial class OrderDetail
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public int OrderID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}
