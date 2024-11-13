using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TVCaKoi.WebApp.DAL;

namespace TVCaKoi.WebApp.Pages.Admin.User
{
    public class CreateModel : PageModel
    {

        private readonly ApptvcakoiContext _apptvcakoiContext;

        public CreateModel(ApptvcakoiContext apptvcakoiContext)
        {
            _apptvcakoiContext = apptvcakoiContext;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public QlUser Users { get; set; }
		public async Task<IActionResult> OnPost()
		{
			if (!ModelState.IsValid || _apptvcakoiContext.QlUsers == null || Users == null)
			{
				return Page();
			}

            // Kiểm tra nếu Username đã tồn tại
            var existingUser = await _apptvcakoiContext.QlUsers.FirstOrDefaultAsync(u => u.Username == Users.Username);

            if (existingUser != null)
            {
                // Thêm lỗi vào ModelState và hiển thị thông báo
                ModelState.AddModelError("Users.Username", "Username đã tồn tại. Vui lòng chọn tên khác.");
                return Page();
            }

            _apptvcakoiContext.QlUsers.Add(Users);
			await _apptvcakoiContext.SaveChangesAsync();
            TempData["SuccessMessage"] = "Tài khoản đã được tạo thành công!";
            return RedirectToPage("Index");
        }
    }
}
