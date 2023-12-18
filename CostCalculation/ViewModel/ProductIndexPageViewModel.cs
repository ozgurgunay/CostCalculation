using CostCalculation.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace CostCalculation.ViewModel
{
    public class ProductIndexPageViewModel
    {
        public IEnumerable<Product>? Products { get; set; }
        public IEnumerable<Freight>? FreightInfoList { get; set; }
    }
}
