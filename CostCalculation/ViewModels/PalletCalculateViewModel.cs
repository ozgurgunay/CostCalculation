﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace CostCalculation.ViewModels
{
    [Keyless]
    public class PalletCalculateViewModel
    {
        public decimal NumberOfBox { get; set; }
        public decimal BrütKg { get; set; }
        public decimal PaletBrütKg { get; set; }
        public decimal NetKg { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal SecondQualityPrice { get; set; }
        public decimal SecondQualityCost { get; set; }
        public decimal PackagingPriceTotal { get; set; }
        public decimal LaborCost { get; set; }
        public decimal StoppagejCost { get; set; }
        public decimal TotalCost { get; set; }

        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal OutRate { get; set; }
        public string? UpdateDate { get; set; }

    }
}
