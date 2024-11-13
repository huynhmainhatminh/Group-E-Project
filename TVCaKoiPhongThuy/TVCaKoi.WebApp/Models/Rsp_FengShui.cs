namespace TVCaKoi.WebApp.Models
{
    public class PhongThuyResponse
    {
        public DataPhongThuy data { get; set; }
        public bool success { get; set; }
        public string message { get; set; }
    }

    public class DataPhongThuy
    {
        public int IdqlParameter { get; set; }

        public string NameDestiny { get; set; }

        public string NumberFish { get; set; }

        public string Direction { get; set; }

        public string? Color { get; set; }

        public string? ColorFit { get; set; }

        public string? ColorNotFit { get; set; }
    }

}
