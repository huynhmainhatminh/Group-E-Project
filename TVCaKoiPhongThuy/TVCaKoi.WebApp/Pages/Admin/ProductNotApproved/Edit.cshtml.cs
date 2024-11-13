using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TVCaKoi.WebApp.DAL;
using TVCaKoi.WebApp.Models;

namespace TVCaKoi.WebApp.Pages.Admin.ProductNotApproved
{
    public class EditModel : PageModel
    {
        private readonly ApptvcakoiContext _apptvcakoiContext;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public EditModel(ApptvcakoiContext apptvcakoiContext, IWebHostEnvironment webHostEnvironment)
        {
            _apptvcakoiContext = apptvcakoiContext;
            _webHostEnvironment = webHostEnvironment;
        }


        [BindProperty]
        public ProductUser productsuser { get; set; }

        [BindProperty]
        public IFormFile Image { get; set; } // Nhận ảnh từ form

        public async Task<IActionResult> OnGetAsync(int? itemid)
        {
            if (itemid == null || _apptvcakoiContext.ProductUsers == null)
            {
                return NotFound();
            }
            var sanpham = await _apptvcakoiContext.ProductUsers.FirstOrDefaultAsync(p => p.IdproductUser == itemid);
            if (sanpham == null)
            {
                return NotFound();
            }
            productsuser = sanpham;
            return Page();
        }


        public async Task<IActionResult> OnPostAsync(int? itemid)
        {
            if (itemid == null)
            {
                return NotFound();
            }

            // Lấy sản phẩm hiện tại từ cơ sở dữ liệu
            var existingProduct = await _apptvcakoiContext.ProductUsers.FirstOrDefaultAsync(p => p.IdproductUser == itemid);

            if (existingProduct == null)
            {
                return NotFound();
            }

            // Cập nhật các thuộc tính của sản phẩm
            existingProduct.NameProduct = productsuser.NameProduct;
            existingProduct.Description = productsuser.Description;
            existingProduct.ColorProduct = productsuser.ColorProduct;
            existingProduct.DestinyProduct = productsuser.DestinyProduct;
            existingProduct.IdproductType = productsuser.IdproductType;

            // Kiểm tra nếu có ảnh mới được tải lên
            if (Image != null)
            {
                // Đường dẫn thư mục ảnh
                var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "KOI_USER");

                // Tạo thư mục nếu chưa tồn tại
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                // Tạo tên file duy nhất
                var fileName = Path.GetFileName(Image.FileName);
                var filePath = Path.Combine(uploadsFolder, fileName);

                // Lưu file mới vào thư mục `KOI`
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await Image.CopyToAsync(stream);
                }

                // Cập nhật đường dẫn ảnh
                existingProduct.ImgProduct = $"~/KOI_USER/{fileName}";
            }

            // Lưu thay đổi vào cơ sở dữ liệu
            _apptvcakoiContext.Attach(existingProduct).State = EntityState.Modified;
            await _apptvcakoiContext.SaveChangesAsync();

            TempData["SuccessMessage"] = "Cập nhật sản phẩm thành công!";
            return RedirectToPage("Index"); // Chuyển hướng sau khi cập nhật thành công
        }
    }
}
