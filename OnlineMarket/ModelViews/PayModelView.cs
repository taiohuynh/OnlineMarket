using System.ComponentModel.DataAnnotations;

namespace OnlineMarket.ModelViews
{
	public class PayModelView
	{
        public int CustomerId { get; set; }
        public string? FullName { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập Họ và Tên")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "Địa chỉ nhận hàng")]
        public string? Address { get; set; }
        public int PaymentID { get; set; }
        public string? Note { get; set; }
    }
}
