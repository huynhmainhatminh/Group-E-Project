namespace TVCaKoi.WebApp.Models
{
    public class Product
    {
        public int Idproduct { get; set; }
        public string NameProduct { get; set; }
        public string Description { get; set; }
        public string Username { get; set; }
        public string ColorProduct { get; set; }
        public string DestinyProduct { get; set; }
        public string ImgProduct { get; set; }
        public int IdproductType { get; set; }
    }

    public class ApiData
    {
        public List<Product> Data { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }
    }

    public class ApiResponse
    {
        public ApiData Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
