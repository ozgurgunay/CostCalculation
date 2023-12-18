namespace CostCalculation.DTOs
{
    public class ExchangeCurrencyDTO
    {
        public DateTime Date { get; set; }
        public double BanknoteSelling { get; set; }
        public string? CurrencyName { get; set; }
        public string? CurrencyCode { get; set; }
    }
}
