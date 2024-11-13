using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TVCaKoi.WebApp.Pages.Admin
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Ví dụ xác thực tài khoản. Thay thế bằng cách gọi API hoặc kiểm tra DB của bạn.
            if (Username == "admin" && Password == "password") // Thay "admin" và "password" bằng thông tin thực tế
            {
                // Tạo danh sách các claim
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, Username)
                };

                // Tạo identity và principal
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                // Đăng nhập người dùng
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                // Chuyển hướng sau khi đăng nhập thành công
                return RedirectToPage("/Admin/Index");
            }
            else
            {
                // Thông báo lỗi nếu đăng nhập không thành công
                ErrorMessage = "Tên đăng nhập hoặc mật khẩu không đúng.";
                return Page();
            }
        }
    }
}
