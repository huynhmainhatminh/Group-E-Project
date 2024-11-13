using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TVCaKoi.WebApp.DAL;
using TVCaKoi.WebApp.Models;
using System;
using System.IO;
using System.Threading.Tasks;

namespace TVCaKoi.WebApp.Pages.Admin.ProductNotApproved
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
        public ProductUser productsuser { get; set; }

        [BindProperty]
        public IFormFile Image { get; set; } // Nhận ảnh từ form

        public async Task<IActionResult> OnPostAsync()
        {
            // Kiểm tra nếu `Username` đã tồn tại trong cơ sở dữ liệu
            var existingProduct = await _apptvcakoiContext.QlUsers
                .FirstOrDefaultAsync(p => p.Username == productsuser.Username);

            if (existingProduct == null)
            {
                ModelState.AddModelError("productsuser.Username", "Username không tồn tại. Bạn cần nhập Username đã tồn tại.");
                return Page();
            }

            // Kiểm tra xem người dùng có chọn loại sản phẩm hợp lệ không
            if (productsuser.IdproductType == 0)
            {
                ModelState.AddModelError("productsuser.IdproductType", "Vui lòng chọn loại sản phẩm hợp lệ.");
                return Page();
            }

            // Kiểm tra nếu có ảnh tải lên
            if (Image != null)
            {
                // Kiểm tra xem file có phải là ảnh không (bạn có thể mở rộng để chỉ chấp nhận các định dạng như .jpg, .png)
                var supportedTypes = new[] { "image/jpeg", "image/png", "image/gif" };
                if (!Array.Exists(supportedTypes, t => t == Image.ContentType))
                {
                    ModelState.AddModelError("Image", "Vui lòng chọn một tệp ảnh hợp lệ (JPG, PNG, GIF).");
                    return Page();
                }

                try
                {
                    // Đường dẫn đến thư mục `wwwroot/KOI_USER`
                    var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "KOI_USER");

                    // Tạo thư mục nếu nó chưa tồn tại
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    // Tạo tên file duy nhất bằng GUID và giữ phần mở rộng gốc
                    var fileExtension = Path.GetExtension(Image.FileName);
                    var uniqueFileName = $"{Guid.NewGuid()}{fileExtension}";
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    // Lưu file vào thư mục `KOI_USER`
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await Image.CopyToAsync(stream);
                    }

                    // Lưu đường dẫn ảnh vào `ImgProduct` (định dạng URL với "~")
                    productsuser.ImgProduct = $"~/KOI_USER/{uniqueFileName}";
                }
                catch (Exception ex)
                {
                    // Ghi log lỗi và hiển thị thông báo cho người dùng
                    ModelState.AddModelError("Image", $"Có lỗi xảy ra khi lưu ảnh: {ex.Message}");
                    return Page();
                }
            }

            // Thêm sản phẩm mới vào cơ sở dữ liệu
            _apptvcakoiContext.ProductUsers.Add(productsuser);
            await _apptvcakoiContext.SaveChangesAsync();
            TempData["SuccessMessage"] = "Sản phẩm đã được tạo thành công!";
            return RedirectToPage(nameof(Index)); // Chuyển hướng sau khi thêm thành công
        }
    }
}
