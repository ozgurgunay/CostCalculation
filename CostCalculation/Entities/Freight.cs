namespace CostCalculation.Entities
{
    public class Freight
    {
        public int Id { get; set; }
        public decimal FreightValue { get; set; }
        public int BigPalletNumber { get; set; }
        public int SmallPalletNumber { get; set; }
        public DateTime Date { get; set; }
    }
}
