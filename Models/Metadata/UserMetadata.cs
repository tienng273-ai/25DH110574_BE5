using System.ComponentModel.DataAnnotations;

namespace BE5_CustomerSite.Models.Metadata
{
    public class UserMetadata
    {
        [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập.")]
        [StringLength(255, ErrorMessage = "Tên đăng nhập tối đa 255 ký tự.")]
        [Display(Name = "Tên đăng nhập")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu.")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Mật khẩu từ 6 đến 50 ký tự.")]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [Required]
        [StringLength(1)]
        [Display(Name = "Vai trò")]
        public string UserRole { get; set; }
    }
}
