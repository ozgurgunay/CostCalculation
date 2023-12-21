using Microsoft.EntityFrameworkCore;

namespace CostCalculation.ViewModels
{
    [Keyless]
    public class ExchangeCalculateViewModel
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public decimal FOBEuroKg { get; set; }
        public decimal FOBEuroKasa { get; set; }
        public decimal KasaNakliyeBedeli { get; set; }
        public decimal KgNakliyeBedeli { get; set; }
        public decimal KgEuroCPT { get; set; }
        public decimal KasaEuroCPT { get; set; }
        public decimal PaketEuroCPT { get; set; }
        public decimal TutarEuroFOB { get; set; }
        public decimal TutarEuroCPT { get; set; }
        public double EuroKur { get; set; }
        public decimal Navlun { get; set; }
        public decimal BPalNavlun { get; set; }
        public decimal KPalNavlun { get; set; }
    }
}
