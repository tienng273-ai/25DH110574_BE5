using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace BE5_CustomerSite.Models
{
    [MetadataType(typeof(Metadata.OrderMetadata))]
    public partial class Order
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentStatus { get; set; }
        public string AddressDelivery { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
