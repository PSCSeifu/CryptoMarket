namespace CryptoMarket.Services
{
    public class PriceServicesResult
    {
        public bool Success { get; set; }
        public string BaseCurrrency { get; set; }
        public string Currency { get; set; }
        public double Price { get; set; }
        public double Volume { get; set; }
        public double OneHourChange { get; set; }
        public double TimeStamp { get; set; }
        public string Error { get; set; }

    }
}