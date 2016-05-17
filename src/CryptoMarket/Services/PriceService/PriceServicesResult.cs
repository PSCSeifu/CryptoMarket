namespace CryptoMarket.Services
{
    public class PriceServicesResult
    {
        public bool Success { get; set; }
        public double TimeStamp { get; set; }
        public string Error { get; set; }

        public string FiatCode { get; set; }
        public string CryptoCode { get; set; }
        public double Price { get; set; }
        public double Volume { get; set; }
        public double OneHourChange { get; set; }
    }
}