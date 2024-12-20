﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TVCaKoi.WebApp.DAL;
using TVCaKoi.WebApp.Models;

namespace TVCaKoi.WebApp.Pages.Admin.ProductNotApproved
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ApptvcakoiContext _apptvcakoiContext;

        public IndexModel(ApptvcakoiContext apptvcakoiContext)
        {
            _apptvcakoiContext = apptvcakoiContext;
        }

        public List<ProductUser> productsuser { get; set; } = new List<ProductUser>();

        [BindProperty(SupportsGet = true)]
        public string SearchQuery { get; set; } // Từ khóa tìm kiếm

        public async Task<IActionResult> OnGetAsync()
        {
            // Kiểm tra nếu có từ khóa tìm kiếm
            IQueryable<ProductUser> query = _apptvcakoiContext.ProductUsers;
            if (!string.IsNullOrEmpty(SearchQuery))
            {
                // Tìm kiếm theo tên, username, email hoặc bất kỳ thuộc tính nào mong muốn
                query = query.Where(u => u.NameProduct.Contains(SearchQuery)
                                      || u.Username.Contains(SearchQuery)
                                      || u.DestinyProduct.Contains(SearchQuery)
                                      || u.DestinyProduct.Contains(SearchQuery)
                                      || u.ColorProduct.Contains(SearchQuery));
            }

            // Lấy kết quả từ cơ sở dữ liệu
            productsuser = await query.ToListAsync();
            return Page();
        }
    }
}
