using System;
using System.ComponentModel.DataAnnotations;

namespace BE5_CustomerSite.Models.Metadata
{
    public class OrderMetadata
    {
        [Key]
        public int OrderID { get; set; }

        [Required]
        [Display(Name = "Mã khách hàng")]
        public int CustomerID { get; set; }

        [Required]
        [Display(Name = "Ngày đặt hàng")]
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }

        [Required]
        [Range(typeof(decimal), "0", "9999999999999999")]
        [Display(Name = "Tổng tiền")]
        public decimal TotalAmount { get; set; }

        [Display(Name = "Trạng thái thanh toán")]
        public string PaymentStatus { get; set; }

        [Required]
        [Display(Name = "Địa chỉ giao hàng")]
        public string AddressDelivery { get; set; }
    }
}
