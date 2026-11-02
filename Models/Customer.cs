using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace BE5_CustomerSite.Models
{
    [MetadataType(typeof(Metadata.CustomerMetadata))]
    public partial class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerAddress { get; set; }
        public string Username { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
