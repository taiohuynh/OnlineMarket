using System.ComponentModel.DataAnnotations;

namespace OnlineMarket.ModelViews
{
    public class LoginModelView
    {
        [Key]
        [MaxLength(100)]
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ Email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Display(Name = "Địa chỉ Email")]
        public string Username { get; set; }


        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [MinLength(5, ErrorMessage = "Mật khẩu phải tối thiểu 5 kí tự")]
        public string Password { get; set; }
    }
}
