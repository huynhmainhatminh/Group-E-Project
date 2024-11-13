using System.ComponentModel.DataAnnotations;

namespace TVCaKoi.WebApp.DAL
{
    public class InputReg
    {
        [Required(ErrorMessage = "Họ và Tên không được bỏ trống.")]
        public string NameUser { get; set; } = null!;

        [RegularExpression(@"^[A-Za-z][A-Za-z\d]{3,}$",
        ErrorMessage = "Tên phải có ít nhất 4 ký tự và bắt đầu bằng một chữ cái.")]
        public string Username { get; set; } = null!;

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
       ErrorMessage = "Mật khẩu phải có ít nhất 8 ký tự, bao gồm chữ hoa, chữ thường, số và ký tự đặc biệt.")]
        public string PassUser { get; set; } = null!;

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
       ErrorMessage = "Mật khẩu phải có ít nhất 8 ký tự, bao gồm chữ hoa, chữ thường, số và ký tự đặc biệt.")]
        public string ConfirmPassUser { get; set; } = null!;
    }
}
