using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TVCaKoi.WebApp.Models;
using Newtonsoft.Json;

namespace TVCaKoi.WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient _client;
        private readonly ILogger<IndexModel> _logger;


        public IndexModel(ILogger<IndexModel> logger)
        {
            _client = new HttpClient();
            _logger = logger;
        }

        public ApiResponse ApiResponse { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }

        public async Task<IActionResult> OnGetAsync(int currentPage = 1, int type_product = 2)
        {
            CurrentPage = currentPage;

            HttpResponseMessage countResponse = await _client.GetAsync($"https://localhost:7254/api/Product/get-count-product?Id_Type={type_product}");
            if (!countResponse.IsSuccessStatusCode)
            {
                _logger.LogError("Error fetching product count: " + countResponse.StatusCode);
                return Page();
            }

            var countJsonString = await countResponse.Content.ReadAsStringAsync();
            var countApiResponse = JsonConvert.DeserializeObject<Rsp_Count>(countJsonString);
            var totalProducts = countApiResponse?.Data ?? 1;  // Sửa để lấy giá trị trực tiếp
            TotalPages = (int)Math.Ceiling((double)totalProducts / 8);

            HttpResponseMessage response = await _client.GetAsync($"https://localhost:7254/api/Product/get-product?Pages={currentPage}&Id_Type={type_product}");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                ApiResponse = JsonConvert.DeserializeObject<ApiResponse>(jsonString);
                return Page();
            }
            else
            {
                _logger.LogError("Error fetching products: " + response.StatusCode);
                return RedirectToPage("Error");
            }
        } 
    }
}
