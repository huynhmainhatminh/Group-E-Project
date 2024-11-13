using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading.Tasks;
using TVCaKoi.WebApp.DAL;

namespace TVCaKoi.WebApp.Pages.Admin.ProductNotApproved
{
    public class ApproveModel : PageModel
    {
        private readonly ApptvcakoiContext _apptvcakoiContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<ApproveModel> _logger;

        public ApproveModel(ApptvcakoiContext apptvcakoiContext, IWebHostEnvironment webHostEnvironment, ILogger<ApproveModel> logger)
        {
            _apptvcakoiContext = apptvcakoiContext;
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
        }

        [BindProperty]
        public ProductUser productsuser { get; set; } // Dữ liệu sản phẩm chưa duyệt

        [BindProperty]
        public ProductHome productss { get; set; } // Dữ liệu sản phẩm đã duyệt

        public async Task<IActionResult> OnGetAsync(int? itemid)
        {
            if (itemid == null || _apptvcakoiContext.ProductUsers == null)
            {
                _logger.LogWarning("Không tìm thấy sản phẩm với ID {ItemId}", itemid);
                return NotFound();
            }

            var sanpham = await _apptvcakoiContext.ProductUsers.FirstOrDefaultAsync(p => p.IdproductUser == itemid);
            if (sanpham == null)
            {
                _logger.LogWarning("Sản phẩm với ID {ItemId} không tồn tại", itemid);
                return NotFound();
            }

            productsuser = sanpham;
            _logger.LogInformation("Đã tìm thấy sản phẩm với ID {ItemId}", itemid);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (productsuser == null)
            {
                _logger.LogError("Không tìm thấy sản phẩm để duyệt.");
                return NotFound("Không tìm thấy sản phẩm để duyệt.");
            }

            // Tạo đối tượng `ProductHome` từ `ProductUser`
            productss = new ProductHome
            {
                NameProduct = productsuser.NameProduct,
                Description = productsuser.Description,
                Username = productsuser.Username,
                ColorProduct = productsuser.ColorProduct,
                DestinyProduct = productsuser.DestinyProduct,
                IdproductType = productsuser.IdproductType
            };

            // Đường dẫn gốc của thư mục wwwroot
            var rootPath = _webHostEnvironment.WebRootPath;
            _logger.LogInformation("Bắt đầu xử lý di chuyển ảnh sản phẩm cho sản phẩm ID {ProductId}", productsuser.IdproductUser);

            // Kiểm tra xem đường dẫn ảnh có hợp lệ không
            _logger.LogInformation("Đường dẫn ảnh hiện tại của sản phẩm: {ImgProduct}", productsuser.ImgProduct);

            // Kiểm tra nếu có hình ảnh và nó nằm trong thư mục KOI_USER
            if (!string.IsNullOrEmpty(productsuser.ImgProduct) && productsuser.ImgProduct.Contains("KOI_USER"))
            {
                // Đường dẫn tuyệt đối đến ảnh nguồn trong thư mục KOI_USER
                var sourceImagePath = Path.Combine(rootPath, productsuser.ImgProduct.TrimStart('~', '/'));
                var fileName = Path.GetFileName(sourceImagePath);
                var targetImagePath = Path.Combine(rootPath, "KOI", fileName);

                _logger.LogInformation("Đường dẫn ảnh tuyệt đối nguồn: {SourceImagePath}", sourceImagePath);
                _logger.LogInformation("Đường dẫn ảnh tuyệt đối đích: {TargetImagePath}", targetImagePath);

                try
                {
                    // Kiểm tra và tạo thư mục KOI nếu chưa tồn tại
                    var koiDirectoryPath = Path.Combine(rootPath, "KOI");
                    if (!Directory.Exists(koiDirectoryPath))
                    {
                        _logger.LogInformation("Thư mục đích KOI không tồn tại, tạo mới thư mục.");
                        Directory.CreateDirectory(koiDirectoryPath);
                    }

                    // Di chuyển ảnh từ KOI_USER sang KOI nếu file tồn tại
                    if (System.IO.File.Exists(sourceImagePath))
                    {
                        System.IO.File.Move(sourceImagePath, targetImagePath);
                        productss.ImgProduct = $"~/KOI/{fileName}";
                        _logger.LogInformation("Đã di chuyển ảnh sản phẩm từ {Source} đến {Target}", sourceImagePath, targetImagePath);
                    }
                    else
                    {
                        _logger.LogWarning("Ảnh không tồn tại tại đường dẫn nguồn: {SourceImagePath}", sourceImagePath);
                        ModelState.AddModelError(string.Empty, $"Ảnh không tồn tại tại: {sourceImagePath}");
                        return Page();
                    }
                }
                catch (IOException ex)
                {
                    _logger.LogError(ex, "Lỗi khi di chuyển ảnh từ {Source} đến {Target}", sourceImagePath, targetImagePath);
                    ModelState.AddModelError(string.Empty, $"Lỗi khi di chuyển ảnh: {ex.Message}");
                    return Page();
                }
                catch (UnauthorizedAccessException ex)
                {
                    _logger.LogError(ex, "Lỗi quyền truy cập khi di chuyển ảnh từ {Source} đến {Target}", sourceImagePath, targetImagePath);
                    ModelState.AddModelError(string.Empty, $"Lỗi quyền truy cập khi di chuyển ảnh: {ex.Message}");
                    return Page();
                }
            }
            else
            {
                productss.ImgProduct = productsuser.ImgProduct;
                _logger.LogInformation("Không cần di chuyển ảnh vì ảnh không nằm trong thư mục KOI_USER hoặc không có ảnh.");
            }

            // Thêm sản phẩm đã duyệt vào bảng `ProductHome`
            _apptvcakoiContext.Products.Add(productss);
            _apptvcakoiContext.ProductUsers.Remove(productsuser);
            await _apptvcakoiContext.SaveChangesAsync();

            TempData["SuccessMessage"] = "Sản phẩm đã được duyệt thành công!";
            _logger.LogInformation("Sản phẩm với ID {ProductId} đã được duyệt thành công và thêm vào ProductHome", productsuser.IdproductUser);
            return RedirectToPage("Index");
        }
    }
}
