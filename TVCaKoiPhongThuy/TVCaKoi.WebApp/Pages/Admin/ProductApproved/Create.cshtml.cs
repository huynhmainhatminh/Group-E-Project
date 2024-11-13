using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Threading.Tasks;
using TVCaKoi.WebApp.DAL;

namespace TVCaKoi.WebApp.Pages.Admin.ProductApproved
{
    public class CreateModel : PageModel
    {
        private readonly ApptvcakoiContext _apptvcakoiContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CreateModel(ApptvcakoiContext apptvcakoiContext, IWebHostEnvironment webHostEnvironment)
        {
            _apptvcakoiContext = apptvcakoiContext;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ProductHome productss { get; set; }

        [BindProperty]
        public IFormFile Image { get; set; } // Nhận ảnh từ form

        public async Task<IActionResult> OnPost()
        {
            // Kiểm tra nếu `Username` đã tồn tại trong cơ sở dữ liệu
            var existingProduct = await _apptvcakoiContext.QlUsers
                .FirstOrDefaultAsync(p => p.Username == productss.Username);

            if (existingProduct == null)
            {
                ModelState.AddModelError("productss.Username", "Username không tồn tại. Bạn cần nhập Username đã tồn tại.");
                return Page();
            }

            // Kiểm tra xem người dùng có chọn loại sản phẩm hợp lệ không
            if (productss.IdproductType == 0)
            {
                ModelState.AddModelError("productss.IdproductType", "Vui lòng chọn loại sản phẩm hợp lệ.");
                return Page();
            }

            // Kiểm tra nếu có ảnh tải lên
            if (Image != null)
            {
                // Đường dẫn đến thư mục `wwwroot/KOI`
                var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "KOI");

                // Tạo thư mục nếu nó chưa tồn tại
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                // Lấy tên file duy nhất và tạo đường dẫn
                var fileName = Path.GetFileName(Image.FileName);
                var filePath = Path.Combine(uploadsFolder, fileName);

                // Lưu file vào thư mục `KOI`
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await Image.CopyToAsync(stream);
                }

                // Lưu đường dẫn ảnh vào `ImgProduct` (định dạng URL với "~")
                productss.ImgProduct = $"~/KOI/{fileName}";
            }

            // Thêm sản phẩm mới vào cơ sở dữ liệu
            _apptvcakoiContext.Products.Add(productss);
            await _apptvcakoiContext.SaveChangesAsync();
            TempData["SuccessMessage"] = "Sản phẩm đã được tạo thành công!";
            return RedirectToPage(nameof(Index)); // Chuyển hướng sau khi thêm thành công
        }
    }
}
