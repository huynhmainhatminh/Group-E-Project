using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using TVCaKoi.WebApp.DAL;
using System.Text.Json;
using TVCaKoi.WebApp.Models;


namespace TVCaKoi.WebApp.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly HttpClient _client;
        private readonly ILogger<IndexModel> _logger;


        public RegisterModel(ILogger<IndexModel> logger)
        {
            _client = new HttpClient();
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public InputReg inputreg { get; set; }

        public RspBase rspbase { get; set; }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // So sánh PassUser và ConfirmPassUser
            if (inputreg.PassUser != inputreg.ConfirmPassUser)
            {
                ModelState.AddModelError(string.Empty, "Mật khẩu và xác nhận mật khẩu không khớp.");
                return Page();
            }

            // Tạo đối tượng với các thuộc tính cần thiết cho API
            var apiData = new
            {
                nameUser = inputreg.NameUser,
                username = inputreg.Username,
                passUser = inputreg.PassUser
            };

            var jsonData = JsonSerializer.Serialize(apiData);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            // Gửi yêu cầu POST đến API
            var response = await _client.PostAsync("https://localhost:7254/api/User/register-user", content);

            if (response.IsSuccessStatusCode)
            {
                // Đọc nội dung JSON từ phản hồi và deserialize thành `RspBase`
                var responseContent = await response.Content.ReadAsStringAsync();
                rspbase = JsonSerializer.Deserialize<RspBase>(responseContent);

                if (rspbase != null && rspbase.Title == "Error")
                {
                    // Nếu `Title` là "Error", hiển thị thông báo lỗi từ `Message`
                    ModelState.AddModelError(string.Empty, rspbase.Message ?? "Đăng ký không thành công. Vui lòng thử lại.");
                    return Page();
                }

                // Chuyển hướng sau khi đăng ký thành công
                TempData["SuccessMessage"] = "Đăng Ký Tài Khoản Thành Công";
                return RedirectToPage("/Index");
            }
            else
            {
                // Ghi log lỗi kết nối API nếu phản hồi thất bại
                _logger.LogError("Lỗi không mong muốn khi kết nối với API.");
                ModelState.AddModelError(string.Empty, "Lỗi kết nối. Vui lòng thử lại.");
                return Page();
            }
        }
    }
}
