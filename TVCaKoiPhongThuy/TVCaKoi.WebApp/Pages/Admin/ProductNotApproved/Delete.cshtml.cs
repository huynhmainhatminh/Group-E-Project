using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TVCaKoi.WebApp.DAL;
using TVCaKoi.WebApp.Models;

namespace TVCaKoi.WebApp.Pages.Admin.ProductNotApproved
{
    public class DeleteModel : PageModel
    {

        private readonly ApptvcakoiContext _apptvcakoiContext;

        public DeleteModel(ApptvcakoiContext apptvcakoiContext)
        {
            _apptvcakoiContext = apptvcakoiContext;
        }

        [BindProperty]
        public ProductUser productsuser { get; set; }

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

            _apptvcakoiContext.ProductUsers.Remove(productsuser);
            await _apptvcakoiContext.SaveChangesAsync();

            TempData["SuccessMessage"] = "Xóa sản phẩm thành công!";

            // Chuyển hướng sau khi xóa thành công
            return RedirectToPage("Index");
        }
    }
}
