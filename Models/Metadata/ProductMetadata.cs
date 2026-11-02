using System.ComponentModel.DataAnnotations;

namespace BE5_CustomerSite.Models.Metadata
{
    public class ProductMetadata
    {
        [Key]
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn danh mục.")]
        [Display(Name = "Danh mục")]
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên sản phẩm.")]
        [Display(Name = "Tên sản phẩm")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mô tả sản phẩm.")]
        [Display(Name = "Mô tả")]
        public string ProductDescription { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập giá sản phẩm.")]
        [Range(typeof(decimal), "0.01", "9999999999999999", ErrorMessage = "Giá phải lớn hơn 0.")]
        [Display(Name = "Giá")]
        [DataType(DataType.Currency)]
        public decimal ProductPrice { get; set; }

        [Display(Name = "Hình ảnh")]
        public string ProductImage { get; set; }
    }
}
