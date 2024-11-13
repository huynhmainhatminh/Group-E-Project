using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TVCaKoi.WebApp.DAL;

namespace TVCaKoi.WebApp.Pages.Admin.Product
{
    public class DeleteModel : PageModel
    {
        private readonly ApptvcakoiContext _apptvcakoiContext;

        public DeleteModel(ApptvcakoiContext apptvcakoiContext)
        {
            _apptvcakoiContext = apptvcakoiContext;
        }

        [BindProperty]
        public ProductHome productss { get; set; }


        public async Task<IActionResult> OnGetAsync(int? itemid)
        {
            if (itemid == null || _apptvcakoiContext.Products == null)
            {
                return NotFound();
            }
            var sanpham = await _apptvcakoiContext.Products.FirstOrDefaultAsync(p => p.Idproduct == itemid);
            if (sanpham == null)
            {
                return NotFound();
            }
            productss = sanpham;
            return Page();
        }


        public async Task<IActionResult> OnPostAsync(int? itemid)
        {
            if (itemid == null)
            {
                return NotFound();
            }

            _apptvcakoiContext.Products.Remove(productss);
            await _apptvcakoiContext.SaveChangesAsync();

            TempData["SuccessMessage"] = "Xóa sản phẩm thành công!";

            // Chuyển hướng sau khi xóa thành công
            return RedirectToPage("Index");
        }
    }
}
