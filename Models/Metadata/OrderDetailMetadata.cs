using System.ComponentModel.DataAnnotations;

namespace BE5_CustomerSite.Models.Metadata
{
    public class OrderDetailMetadata
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Sản phẩm")]
        public int ProductID { get; set; }

        [Required]
        [Display(Name = "Đơn hàng")]
        public int OrderID { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Số lượng phải lớn hơn 0.")]
        [Display(Name = "Số lượng")]
        public int Quantity { get; set; }

        [Required]
        [Range(typeof(decimal), "0.01", "9999999999999999")]
        [Display(Name = "Đơn giá")]
        public decimal UnitPrice { get; set; }
    }
}
