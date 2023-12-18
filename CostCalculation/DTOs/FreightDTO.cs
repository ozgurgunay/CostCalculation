namespace CostCalculation.DTOs
{
    public class FreightDTO
    {
        public int? FreightId { get; set; }
        public decimal FreightValue { get; set; }
        public int BigPalletNumber { get; set; }
        public int SmallPalletNumber { get; set; }
        public DateTime Date { get; set; }
    }
}
