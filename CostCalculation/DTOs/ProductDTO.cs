using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CostCalculation.DTOs
{
    public class ProductDTO
    {
        public int? ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public decimal BoxNetKg { get; set; }
        public decimal BoxBrossKg { get; set; }
        public int PalletBoxCount { get; set; }
        public decimal Pallet { get; set; }
        public decimal BagGr { get; set; }
        public decimal Price { get; set; }
        public decimal OutRate { get; set; }
        public decimal LaborCost { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Boolean UpdateData { get; set; }

    }
}
