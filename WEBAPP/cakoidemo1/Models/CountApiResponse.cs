namespace cakoidemo1.Models
{
    public class CountApiResponse
    {
        public int Data { get; set; }  // Đây là số lượng sản phẩm từ API
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
