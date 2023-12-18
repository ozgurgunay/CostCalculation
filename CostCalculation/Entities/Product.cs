using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CostCalculation.Entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal BoxNetKg { get; set; }
        public int PalletBoxCount { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Pallet { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal BagGr { get; set;}
        [Column(TypeName ="decimal(10,2)")]
        public decimal Price { get; set;}
        [Column(TypeName = "decimal(10,2)")]
        public decimal OutRate { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal LaborCost { get; set;}
        public Boolean DeleteData { get; set; }
        public DateTime CreatedDate { get; set; }
        public Boolean UpdateData { get; set; }
        public DateTime? UpdateDate { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal BoxBrossKg { get; set; }
    }

}
