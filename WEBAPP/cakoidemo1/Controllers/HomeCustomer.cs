using cakoidemo1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace cakoidemo1.Controllers
{
    public class HomeCustomer : Controller
    {
        private readonly HttpClient _client;
        private readonly ILogger<HomeController> _logger;
        Uri baseAddress = new Uri("https://localhost:7254/api");

        public HomeCustomer(ILogger<HomeController> logger)
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
            _logger = logger;
        }


        [HttpGet]
        public async Task<IActionResult> Index(int page = 1)
        {
            HttpResponseMessage countResponse = await _client.GetAsync(_client.BaseAddress + "/Product/get-count-product?Id_Type=2");

            if (!countResponse.IsSuccessStatusCode)
            {
                _logger.LogError("Lỗi khi gọi API lấy tổng số sản phẩm: " + countResponse.StatusCode);
                return View("Error");
            }

            var countJsonString = await countResponse.Content.ReadAsStringAsync();
            var countApiResponse = JsonConvert.DeserializeObject<CountApiResponse>(countJsonString);

            var totalPages = countApiResponse?.Data ?? 1;

            HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + $"/Product/get-product?Pages={page}&Id_Type=2");

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(jsonString);

                ViewBag.CurrentPage = page;
                ViewBag.TotalPages = (int)Math.Ceiling((double)totalPages / 8);

                return View(apiResponse);
            }
            else
            {
                _logger.LogError("Lỗi khi gọi API: " + response.StatusCode);
                return View("Error");
            }
        }


  

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
