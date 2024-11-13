using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TVCaKoi.WebApp.DAL;
using Microsoft.EntityFrameworkCore;

namespace TVCaKoi.WebApp.Pages.Admin
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ApptvcakoiContext _apptvcakoiContext;

        public IndexModel(ApptvcakoiContext apptvcakoiContext)
        {
            _apptvcakoiContext = apptvcakoiContext;
        }

        public int TotalMembers { get; set; }
        public int TotalProductNotApproved { get; set; }
        public int TotalProductApproved { get; set; }

        public async Task OnGetAsync()
        {
            TotalMembers = await _apptvcakoiContext.QlUsers.CountAsync();
            TotalProductNotApproved = await _apptvcakoiContext.ProductUsers.CountAsync();
            TotalProductApproved = await _apptvcakoiContext.Products.CountAsync();
        }
    }
}
