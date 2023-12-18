namespace CostCalculation.DTOs
{
    public class UpdateProductPricesDTO
    {
        public int? ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public decimal Price { get; set; }
        public decimal OutRate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Boolean UpdateData { get; set; }
    }
}
