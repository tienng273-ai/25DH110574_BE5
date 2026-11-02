using System.ComponentModel.DataAnnotations;

namespace BE5_CustomerSite.Models.Metadata
{
    public class CategoryMetadata
    {
        [Key]
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên danh mục.")]
        [Display(Name = "Tên danh mục")]
        public string CategoryName { get; set; }
    }
}
