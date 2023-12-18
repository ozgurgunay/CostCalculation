namespace CostCalculation.Entities
{
    public class ExchangeRate
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public short CrossOrder { get; set; }
        public string? Kod { get; set; }
        public string? CurrencyCode { get; set; }
        public string? UNIT { get; set; }
        public string? Isim { get; set; }
        public string? CurrencyName { get; set; }
        public double ForexBuying { get; set; }
        public double ForexSelling { get; set; }
        public double BanknoteBuying { get; set; }
        public double BanknoteSelling { get; set; }
    }
}
