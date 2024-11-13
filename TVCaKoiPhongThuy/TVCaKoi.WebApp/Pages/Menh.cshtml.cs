using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using TVCaKoi.WebApp.Models;

namespace TVCaKoi.WebApp.Pages
{
    public class MenhModel : PageModel
    {
        private readonly HttpClient _client;
        private readonly ILogger<IndexModel> _logger;


        public MenhModel(ILogger<IndexModel> logger)
        {
            _client = new HttpClient();
            _logger = logger;
        }

        public ApiResponseProduct ApiResponseProducts { get; set; }

        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public string Name_Destiny { get; set; }

        public async Task<IActionResult> OnGetAsync(int currentPage = 1, string destiny = "Thủy")
        {
            CurrentPage = currentPage;
            Name_Destiny = destiny;
            HttpResponseMessage countResponse = await _client.GetAsync($"https://localhost:7254/api/Product/get-count-product-keys?Keys={destiny}");
            if (!countResponse.IsSuccessStatusCode)
            {
                _logger.LogError("Error fetching product count: " + countResponse.StatusCode);
                return Page();
            }
            var countJsonString = await countResponse.Content.ReadAsStringAsync();
            var countApiResponse = JsonConvert.DeserializeObject<Rsp_Count>(countJsonString);
            var totalProducts = countApiResponse?.Data ?? 1;  // Sửa để lấy giá trị trực tiếp
            TotalPages = (int)Math.Ceiling((double)totalProducts / 8);
            HttpResponseMessage response = await _client.GetAsync($"https://localhost:7254/api/Product/get-product-keys-pages?Pages={currentPage}&Keys={destiny}");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                ApiResponseProducts = JsonConvert.DeserializeObject<ApiResponseProduct>(jsonString);
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
