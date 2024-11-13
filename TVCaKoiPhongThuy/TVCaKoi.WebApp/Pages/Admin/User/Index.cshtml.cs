using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TVCaKoi.WebApp.DAL;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace TVCaKoi.WebApp.Pages.Admin.User
{
    public class IndexModel : PageModel
    {
        private readonly ApptvcakoiContext _apptvcakoiContext;

        public IndexModel(ApptvcakoiContext apptvcakoiContext)
        {
            _apptvcakoiContext = apptvcakoiContext;
        }

        public List<QlUser> Users { get; set; } = new List<QlUser>();

        [BindProperty(SupportsGet = true)]
        public string SearchQuery { get; set; } // Từ khóa tìm kiếm

        public async Task<IActionResult> OnGetAsync()
        {
            // Kiểm tra nếu có từ khóa tìm kiếm
            IQueryable<QlUser> query = _apptvcakoiContext.QlUsers;

            if (!string.IsNullOrEmpty(SearchQuery))
            {
                // Tìm kiếm theo tên, username, email hoặc bất kỳ thuộc tính nào mong muốn
                query = query.Where(u => u.NameUser.Contains(SearchQuery)
                                      || u.Username.Contains(SearchQuery)
                                      || u.Phone.Contains(SearchQuery)
                                      || u.AccessUser.Contains(SearchQuery)
                                      || u.Email.Contains(SearchQuery));
            }

            // Lấy kết quả từ cơ sở dữ liệu
            Users = await query.ToListAsync();
            return Page();
        }
    }
}
