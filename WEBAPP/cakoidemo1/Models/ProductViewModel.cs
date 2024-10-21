using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace cakoidemo1.Models
{
    public class ProductViewModel
    {
        public int Idproduct { get; set; }

        [Required]
        [DisplayName("Product Name")]
        public string NameProduct { get; set; } = null!;

        [Required]
        public string? Description { get; set; }
        
        [Required]
        public string Username { get; set; } = null!;

        [Required]
        public string? ColorProduct { get; set; }

        [Required]
        public string? DestinyProduct { get; set; }

        [Required]
        public string? ImgProduct { get; set; }

        [Required]
        public int? IdproductType { get; set; }
    }
}
