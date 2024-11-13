using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TVCaKoi.WebApp.DAL;

public partial class QlUser
{
    public int IdUser { get; set; }

    [Required(ErrorMessage = "Họ và Tên không được bỏ trống.")]
    public string NameUser { get; set; } = null!;

    [RegularExpression(@"^[A-Za-z][A-Za-z\d]{3,}$",
        ErrorMessage = "Tên phải có ít nhất 4 ký tự và bắt đầu bằng một chữ cái.")]
    public string Username { get; set; } = null!;

    [Required(ErrorMessage = "Vui lòng nhập mật khẩu.")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
       ErrorMessage = "Mật khẩu phải có ít nhất 8 ký tự, bao gồm chữ hoa, chữ thường, số và ký tự đặc biệt.")]
    public string PassUser { get; set; } = null!;

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Facebook { get; set; }

    [Required(ErrorMessage = "Vui lòng chọn quyền truy cập.")]
    [RegularExpression("^(?!none$).*", ErrorMessage = "Vui lòng chọn quyền truy cập hợp lệ.")]
    public string? AccessUser { get; set; }

    public virtual ICollection<ProductUser> ProductUsers { get; set; } = new List<ProductUser>();

    public virtual ICollection<ProductHome> Products { get; set; } = new List<ProductHome>();
}
