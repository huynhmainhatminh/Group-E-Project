using System;
using System.Collections.Generic;

namespace TVCaKoi.WebApp.DAL;

public partial class ProductType
{
    public int IdproductType { get; set; }

    public string NameType { get; set; } = null!;

    public virtual ICollection<ProductUser> ProductUsers { get; set; } = new List<ProductUser>();

    public virtual ICollection<ProductHome> Products { get; set; } = new List<ProductHome>();
}
