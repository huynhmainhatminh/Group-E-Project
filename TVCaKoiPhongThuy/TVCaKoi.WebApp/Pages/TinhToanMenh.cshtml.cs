using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using TVCaKoi.WebApp.Models;

namespace TVCaKoi.WebApp.Pages
{
    public class TinhToanMenhModel : PageModel
    {
        private readonly HttpClient _client;
        private readonly ILogger<TinhToanMenhModel> _logger;

        public TinhToanMenhModel(ILogger<TinhToanMenhModel> logger)
        {
            _client = new HttpClient();
            _logger = logger;
        }

        public string MenhNguHanh { get; set; }
        public DataPhongThuy PhongThuyData { get; set; }

        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public DateTime Dob { get; set; }

        [BindProperty]
        public string Sex { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            string[] nguHanh = { "Kim", "Thủy", "Mộc", "Hỏa", "Thổ" };
            int year = Dob.Year;

            int canIndex = year % 10;
            int chiIndex = year % 12;

            int menhIndex = (canIndex % 5 + chiIndex % 2) % 5;
            MenhNguHanh = nguHanh[menhIndex];
            _logger.LogInformation($"Mệnh Ngũ Hành: {MenhNguHanh}");

            HttpResponseMessage response = await _client.GetAsync($"https://localhost:7254/api/FengShui/get-phongthuy-name?Keyword={MenhNguHanh}");
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError($"Error fetching data: {response.StatusCode}");
                return Page();
            }

            var jsonString = await response.Content.ReadAsStringAsync();
            _logger.LogInformation($"API Response: {jsonString}");

            var responseObj = JsonConvert.DeserializeObject<PhongThuyResponse>(jsonString);
            if (responseObj != null && responseObj.success)
            {
                PhongThuyData = responseObj.data;
            }
            else
            {
                _logger.LogError("Deserialization failed or success flag is false.");
            }

            return Page();
        }
    }
}
