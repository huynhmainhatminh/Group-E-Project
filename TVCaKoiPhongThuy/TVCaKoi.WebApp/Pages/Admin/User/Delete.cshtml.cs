using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TVCaKoi.WebApp.DAL;

namespace TVCaKoi.WebApp.Pages.Admin.User
{
    public class DeleteModel : PageModel
    {
        private readonly ApptvcakoiContext _apptvcakoiContext;

        public DeleteModel(ApptvcakoiContext apptvcakoiContext)
        {
            _apptvcakoiContext = apptvcakoiContext;
        }

        [BindProperty]
        public QlUser Users { get; set; }

        public async Task<IActionResult> OnGetAsync(int? itemid)
        {
            if (itemid == null || _apptvcakoiContext.QlUsers == null)
            {
                return NotFound();
            }
            var user = await _apptvcakoiContext.QlUsers.FirstOrDefaultAsync(p => p.IdUser == itemid);
            if (user == null)
            {
                return NotFound();
            }
            Users = user;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? itemid)
        {
            if (itemid == null)
            {
                return NotFound();
            }

            _apptvcakoiContext.QlUsers.Remove(Users);
            await _apptvcakoiContext.SaveChangesAsync();

            TempData["SuccessMessage"] = "Xóa tài khoản thành công!";

            // Chuyển hướng sau khi xóa thành công
            return RedirectToPage("Index");
        }
    }
}
