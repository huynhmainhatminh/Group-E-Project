using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TVCaKoi.WebApp.DAL;

public partial class ProductHome
{
    public int Idproduct { get; set; }

    public string NameProduct { get; set; } = null!;

    public string? Description { get; set; }

    [RegularExpression(@"^[A-Za-z][A-Za-z\d]{3,}$",
        ErrorMessage = "Tên phải có ít nhất 4 ký tự và bắt đầu bằng một chữ cái.")]
    public string Username { get; set; } = null!;

    public string? ColorProduct { get; set; }

    public string? DestinyProduct { get; set; }

    public string? ImgProduct { get; set; }

    public int? IdproductType { get; set; }

    public virtual ProductType? IdproductTypeNavigation { get; set; }

    public virtual QlUser UsernameNavigation { get; set; } = null!;
}
