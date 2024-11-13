namespace TVCaKoi.WebApp.Models
{
    public class RspBase
    {
        public object Data { get; set; }
        public bool Success { get; set; }
        public string Code { get; set; }
        public string Message { get; set; }
        public string Variant { get; set; }
        public string Title { get; set; }
    }
}
